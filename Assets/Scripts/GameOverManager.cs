using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static Action<Vector3> GameOverEvent;

    public AdManager ad;
    
    public GameObject gameOverPanel;

    private void OnEnable()
    {
        GameOverEvent += TriggerGameOver;
    }
    private void OnDisable()
    {
        GameOverEvent -= TriggerGameOver;
    }

    public void TriggerGameOver(Vector3 position)
    {
        StartCoroutine(OpenPanelWithDelay());
    }

    IEnumerator OpenPanelWithDelay()
    {
        yield return new WaitForSeconds(2);
        ad.LoadInterstitialAd();
        ad.ShowInterstitialAd();
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;   
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1f;
    }
}
