
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    /// <summary>
    /// list cam y
    ///  0, 15.96, 31.87, 48, 64.93
    /// </summary>
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject Camera_GO;
    void OnTriggerExit2D(Collider2D other)
    {
        // Debug.Log($"player : {PlayerControler.Instance.transform.position.y}  cameraTrigger : {transform.position.y}" );
        if (other.gameObject.CompareTag("trigerChangeCam"))
        {
            CameraLocationTarget scriptLocationCam = other.gameObject.GetComponent<CameraLocationTarget>();
            // check y postion character between trigger
            if (PlayerControler.Instance.transform.position.y > other.gameObject.transform.position.y)
            {
                // up camera
                Camera_GO.transform.position = scriptLocationCam.locationCamUP;
            }
            else if(PlayerControler.Instance.transform.position.y <= other.gameObject.transform.position.y)
            {
                //down camera
                 Camera_GO.transform.position = scriptLocationCam.locationCamDown;
            }
            
        }
    }
}
