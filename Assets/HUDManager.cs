using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;
    bool isPlay = true;

    [SerializeField]
    CanvasGroup CG_PauseUI;

    [SerializeField]
    TMP_Text footText;
    public float footHeight = 0f;
    public float FootHeight
    {
        get { return footHeight; }
        set
        {
            if (footHeight <= 0)
                footText.text = $"Height : 0 ft";
            else
                footText.text = $"Height : {footHeight.ToString("F2")} ft";

            footHeight = value;
        }
    }

    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame();
    }

    public void ContinueGame()
    {
        isPlay = true;

        // hide ui
        CG_PauseUI.alpha = 0;
        CG_PauseUI.interactable = false;
        CG_PauseUI.blocksRaycasts = false;

        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        if (!isPlay)
            ContinueGame();
        else
        {
            isPlay = false;

            // show ui
            CG_PauseUI.alpha = 1;
            CG_PauseUI.interactable = true;
            CG_PauseUI.blocksRaycasts = true;

            Time.timeScale = 0;
        }
    }

    public void BackToMainMenu()
    {
        //
        SceneManager.LoadScene("HomeScreen");
    }
}
