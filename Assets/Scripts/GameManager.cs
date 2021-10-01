using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float WORLD_SCREEN_WIDTH, WORLD_SCREEN_HEIGHT;
    public static bool paused, ballAlive;
    public static string NORMAL_MODE_SAVE_KEY = "NORMAL_MODE_SAVE";

    private void Start()
    {
        paused = false;
        Time.timeScale = 1;
    }

    public static void GameOver(SceneManager sceneManager)
    {
        paused = true;
        Time.timeScale = 0;
        int highScore = PlayerPrefs.GetInt(NORMAL_MODE_SAVE_KEY);

        sceneManager.GetInGamePanel().SetActive(false);
        
        GameObject gameOverPanel = sceneManager.GetGameOverPanel();

        gameOverPanel.SetActive(true);

        Text scoreText = gameOverPanel.transform.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "Score: " + sceneManager.score.ToString();

        if(sceneManager.score > highScore)
        {
            PlayerPrefs.SetInt(NORMAL_MODE_SAVE_KEY, sceneManager.score);

            highScore = sceneManager.score;
        }

        Text highScoreText = gameOverPanel.transform.Find("HighScoreText").GetComponent<Text>();
        highScoreText.text = "High Score: " + highScore;
    }

    public void StartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
