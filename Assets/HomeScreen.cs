using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // <— untuk RawImage

public class HomeScreen : MonoBehaviour
{
    [SerializeField]
    CanvasGroup CG_setting,
        CG_main;

    [SerializeField]
    RawImage circlePNG;

    void Start()
    {
        // Optional: pastikan awalnya ukuran 1
        if (circlePNG != null)
            circlePNG.transform.localScale = Vector3.one;
    }

    public void StartGame()
    {
        StartCoroutine(StartGameIE());
    }

    IEnumerator StartGameIE()
    {
        Debug.Log("Start Game!");
        // Contoh animasi: fade out main menu dan tampilkan setting
        CG_main.DOFade(0f, 0.5f).SetEase(Ease.OutQuad);
        CG_main.interactable = false;
        CG_main.blocksRaycasts = false;

        CG_setting.DOFade(1f, 0.5f).SetEase(Ease.OutQuad);
        CG_setting.interactable = true;
        CG_setting.blocksRaycasts = true;

        DoScaleCircle(100f, 100f);

        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Cutscene_start");
    }

    public void OpenCredit()
    {
        StartCoroutine(OpenCreditIE());
    }

    IEnumerator OpenCreditIE()
    {
        Debug.Log("Open Credit!");
        // Contoh animasi circle mekar
        DoScaleCircle(100f, 100f);

        yield return new WaitForSeconds(2.5f);

        CG_main.alpha = 0;
        CG_main.interactable = false;
        CG_main.blocksRaycasts = false;


        CG_setting.alpha = 1f;
        CG_setting.interactable = true;
        CG_setting.blocksRaycasts = true;

        DoScaleCircle(1f, 1f);
    }

    public void CloseCredit()
    {
        StartCoroutine(CLoseCreditIE());
    }

    IEnumerator CLoseCreditIE()
    {
        Debug.Log("Close Credit!");
        // Contoh animasi circle mekar
        DoScaleCircle(100f, 100f);

        yield return new WaitForSeconds(2.5f);

        CG_setting.alpha = 0f;
        CG_setting.interactable = false;
        CG_setting.blocksRaycasts = false;

        CG_main.alpha = 1f;
        CG_main.interactable = true;
        CG_main.blocksRaycasts = true;


        DoScaleCircle(1f, 1f);
    }

    public void Quit()
    {
        Debug.Log("Quit Game");
        DoScaleCircle(100f, 100f);
        Application.Quit();
    }

    /// <summary>
    /// Animasi scaling circle image pakai DOTween
    /// </summary>
    public void DoScaleCircle(float targetWidth, float targetHeight)
    {
        if (circlePNG == null)
            return;

        // Tween ke ukuran baru dengan durasi dan easing halus
        circlePNG
            .transform.DOScale(new Vector3(targetWidth, targetHeight, 1f), 1f)
            .SetEase(Ease.OutBack);
    }
}
