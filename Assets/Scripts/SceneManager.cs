using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public static float OBSTACLE_DISCTANCE = 7;
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] GameObject inGamePanel, gameOverPanel, pausedPanel;
    [SerializeField] ButtonAudioSourceBehaviour buttonSoundSourceBehaviour;
    public int score;
    Transform lastObstacleTransform;
    int selector;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.paused = false;
        GameManager.ballAlive = true;
        Time.timeScale = 1;
        score = 0;
        GameManager.WORLD_SCREEN_WIDTH = Camera.main.ScreenToWorldPoint(new Vector2(
            Camera.main.pixelWidth, 0)).x;
        GameManager.WORLD_SCREEN_HEIGHT = Camera.main.ScreenToWorldPoint(new Vector2(
            0, Camera.main.pixelHeight)).y;

        if(!PlayerPrefs.HasKey(GameManager.NORMAL_MODE_SAVE_KEY))
        {
            PlayerPrefs.SetInt(GameManager.NORMAL_MODE_SAVE_KEY, 0);
        }

        GameObject firstObstacle = SpawnObstacle(obstaclePrefabs[0], new Vector2(0, -4),
            obstaclePrefabs[0].name);
        lastObstacleTransform = firstObstacle.transform;
        selector = 1;
        int initialRibbonCount = Mathf.CeilToInt(GameManager.WORLD_SCREEN_HEIGHT /
            OBSTACLE_DISCTANCE) + 1;

        for (int i = 0; i < initialRibbonCount; i++)
        {
            GameObject newObstacle = SpawnObstacle(obstaclePrefabs[selector],
                lastObstacleTransform.position, obstaclePrefabs[selector].name);
            lastObstacleTransform = newObstacle.transform;

            UpdateSelector();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnObstacle(GameObject referencePrefab, Vector2 lastPositon, string name)
    {
        GameObject newGameObject = Instantiate(referencePrefab);
        newGameObject.name = name;
        newGameObject.transform.position = new Vector2(0, lastPositon.y + OBSTACLE_DISCTANCE);

        return newGameObject;
    }

    public void UpdateSelector()
    {
        selector++;
        selector %= 2;
    }

    public int GetSelector()
    {
        return selector;
    }

    public Transform GetLastObstacleTransform()
    {
        return lastObstacleTransform;
    }

    public void SetLastObstacleTransform(Transform lastObstacleTransform)
    {
        this.lastObstacleTransform = lastObstacleTransform;
    }

    public GameObject GetObstaclePrefab(int index)
    {
        return obstaclePrefabs[index];
    }

    public GameObject GetInGamePanel()
    {
        return inGamePanel;
    }

    public GameObject GetGameOverPanel()
    {
        return gameOverPanel;
    }

    public void Pause()
    {
        GameManager.paused = true;
        Time.timeScale = 0;

        inGamePanel.SetActive(false);
        pausedPanel.SetActive(true);
    }

    public void Resume()
    {
        GameManager.paused = false;
        Time.timeScale = 1;

        inGamePanel.SetActive(true);
        pausedPanel.SetActive(false);
    }

    public void Retry()
    {
        buttonSoundSourceBehaviour.isDead = true;

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
