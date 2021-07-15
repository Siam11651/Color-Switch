using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RibbonSystemBehaviour : MonoBehaviour
{
    [SerializeField] GameObject firstRibbon, sceneManagerGameObject;
    SceneManager sceneManager;
    Transform lastRibbonEnd;

    // Start is called before the first frame update
    void Start()
    {
        sceneManagerGameObject = GameObject.Find("SceneManager");
        sceneManager = sceneManagerGameObject.GetComponent<SceneManager>();
        firstRibbon.transform.position = new Vector2(GameManager.WORLD_SCREEN_WIDTH, firstRibbon.transform.position.y);
        lastRibbonEnd = firstRibbon.GetComponent<RibbonBehavior>().GetEndTransform();
        int initialRibbonCount = Mathf.CeilToInt(GameManager.WORLD_SCREEN_WIDTH * 2 / 
            RibbonBehavior.RIBBON_LEGNTH);

        for(int i = 0; i < initialRibbonCount; i++)
        {
            GameObject newRibbon = RibbonBehavior.SpawnRibbon(firstRibbon, gameObject.transform, lastRibbonEnd, firstRibbon.name);
            lastRibbonEnd = newRibbon.GetComponent<RibbonBehavior>().GetEndTransform();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float cameraPositionY = Camera.main.transform.position.y;
        float deepestDepth = GameManager.WORLD_SCREEN_HEIGHT + 7;

        if (transform.position.y < cameraPositionY - deepestDepth)
        {
            GameObject newObstacle = sceneManager.SpawnObstacle(
                sceneManager.GetObstaclePrefab(sceneManager.GetSelector()),
                sceneManager.GetLastObstacleTransform().position, 
                sceneManager.GetObstaclePrefab(sceneManager.GetSelector()).name);

            sceneManager.UpdateSelector();
            sceneManager.SetLastObstacleTransform(newObstacle.transform);
            Destroy(gameObject);
        }
    }

    public Transform GetLastRibbonEnd()
    {
        return lastRibbonEnd;
    }

    public void SetLastRibbonEnd(Transform lastRibbonEnd)
    {
        this.lastRibbonEnd = lastRibbonEnd;
    }
}
