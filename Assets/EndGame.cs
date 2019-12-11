using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject gameOverUI;
    // Update is called once per frame

    public void Pause()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void MenuGame()
    {
        SceneManager.LoadScene("menu");
    }
}

