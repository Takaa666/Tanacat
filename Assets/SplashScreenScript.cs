using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(WaitBeforeGoHome());
    }

    IEnumerator WaitBeforeGoHome()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("Home");
    }
}