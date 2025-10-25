
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // move, jump, raycast (pake spasi, kiri (D) kanan (A))
    [SerializeField]
    bool isJump = false,
        isOnGround = true;

    [SerializeField]
    bool isCanMove = true,
        isCanJump = true,
        isHoldSpace = false;

    [SerializeField]
    float strengthJump = 1f,
        rayDistance = 0.1f,
        strengthFill = 0f; // strenth fill yang mengatur strength jump

    //  enum StateFill
    // {
    //     Increase,
    //     Decrease
    // };

    // [SerializeField]
    // StateFill stateFill;

    [SerializeField]
    Vector2 raycastWidthHeight = new Vector2(0.6f, 0.1f);

    enum DirectionJump
    {
        Left,
        Right,
        Middle
    };

    Rigidbody2D rigidbody2D;

    [SerializeField]
    LayerMask groundLayer; // pilih layer Ground di inspector

    [SerializeField]
    DirectionJump directionPlayer = DirectionJump.Middle;

    public static PlayerControler Instance;

    void Start()
    {
        Instance = this;
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RaycastCheck();

        if (!isCanMove)
            return;

        // key input for direction
        if (Input.GetKeyDown(KeyCode.A))
            ChangeDirectionPlayer(DirectionJump.Left);
            // ChangeDirectionPlayer(DirectionJump.Right);
        else if (Input.GetKeyDown(KeyCode.D))
            ChangeDirectionPlayer(DirectionJump.Right);
            // ChangeDirectionPlayer(DirectionJump.Left);
        else if (Input.GetKeyDown(KeyCode.S))
            ChangeDirectionPlayer(DirectionJump.Middle);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isHoldSpace = true;
            strengthFill = 1f;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
            isHoldSpace = false;
        }

        if (isHoldSpace)
        {
            AddStrenthJumpWhileHold();
        }

        HUDManager.Instance.FootHeight = (transform.position.y * 1.4f);
    }

    /// <summary>
    /// Fungsi yang akan membuat strengthfill berkurang
    /// </summary>
    void AddStrenthJumpWhileHold()
    {
        if (strengthFill <= 0.1f)
            return;
        strengthFill -= 0.005f;
    }

    // void CheckStateFill()
    // {
    //     if (stateFill != StateFill.Decrease && strengthFill >= 1)
    //         stateFill = StateFill.Decrease;
    //     else if (stateFill != StateFill.Increase && strengthFill <= 0)
    //         stateFill = StateFill.Increase;
    // }


    /// <summary>
    /// buat jump action
    /// </summary>
    void Jump()
    {
        if (!isOnGround)
            return;

        Debug.Log("Jump");

        float horizontalDirection = 0f;

        // check direction
        if (directionPlayer == DirectionJump.Left)
            horizontalDirection = 2f; // reverse
        else if (directionPlayer == DirectionJump.Right)
            horizontalDirection = -2f; // reverse

        rigidbody2D.linearVelocity = new Vector2(horizontalDirection, strengthJump * strengthFill);
        strengthFill = 0f;
        isOnGround = false;
        strengthFill = 0f;
    }

    /// <summary>
    /// Buat Check ground
    /// </summary>

    void RaycastCheck()
    {
        // RaycastHit2D hit = Physics2D.Raycast(
        //     transform.position,
        //     Vector2.down,
        //     rayDistance,
        //     groundLayer
        // );

        RaycastHit2D hit = Physics2D.BoxCast(
            transform.position,
            raycastWidthHeight,
            0f,
            Vector2.down,
            rayDistance,
            groundLayer
        );

        // Debug line untuk melihat ray di Scene view
        Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.red);

        Color color = hit.collider != null ? Color.green : Color.red;

        Debug.DrawLine(
            transform.position + (Vector3)new Vector2(-raycastWidthHeight.x / 2, 0),
            transform.position + (Vector3)new Vector2(raycastWidthHeight.x / 2, 0),
            color
        );
        Debug.DrawLine(
            transform.position + (Vector3)new Vector2(-raycastWidthHeight.x / 2, -rayDistance),
            transform.position + (Vector3)new Vector2(raycastWidthHeight.x / 2, -rayDistance),
            color
        );

        // Cek apakah ray mengenai sesuatu
        if (hit.collider != null)
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }

    void ChangeDirectionPlayer(DirectionJump newDirection)
    {
        directionPlayer = newDirection;
    }
}
