using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float WORLD_SCREEN_WIDTH, WORLD_SCREEN_HEIGHT;
    public static bool paused;

    public static void GameOver(SceneManager sceneManager)
    {
        paused = true;
        Time.timeScale = 0;

        sceneManager.GetInGamePanel().SetActive(false);
        sceneManager.GetGameOverPanel().SetActive(true);
    }

    public void StartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }

    public void Exit()
    {
        Application.Quit();
    }
}