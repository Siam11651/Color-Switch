using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float WORLD_SCREEN_WIDTH, WORLD_SCREEN_HEIGHT;
    public static bool paused, ballAlive;
    public static string NORMAL_MODE_SAVE_KEY = "NORMAL_MODE_SAVE";

    public static void GameOver(SceneManager sceneManager)
    {
        paused = true;
        Time.timeScale = 0;
        int lastMaxScore = PlayerPrefs.GetInt(NORMAL_MODE_SAVE_KEY);

        sceneManager.GetInGamePanel().SetActive(false);
        
        GameObject gameOverPanel = sceneManager.GetGameOverPanel();

        gameOverPanel.SetActive(true);

        Text scoreText = gameOverPanel.transform.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "Score: " + sceneManager.score.ToString();

        if(sceneManager.score > lastMaxScore)
        {
            PlayerPrefs.SetInt(NORMAL_MODE_SAVE_KEY, sceneManager.score);

            Text highScoreText = gameOverPanel.transform.Find("HighScoreText").GetComponent<Text>();
            highScoreText.text = "High Score: " + sceneManager.score.ToString();
        }
    }

    public void StartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
