using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delay = 2f;
    [SerializeField] int scoreValue = 5;
    public static int Score = 0;

    IEnumerator WaitingTime()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver");
    }

    private void Update()
    {
        if (Score >= 100)
        {
            LoadWinnerScene();
        }
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");

        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadWinnerScene()
    {
        SceneManager.LoadScene("WinnerScene");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitingTime());
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
