using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static Action<Vector3> GameOverEvent;

    //TODO:  UI MANAGER can open close canvases
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
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
