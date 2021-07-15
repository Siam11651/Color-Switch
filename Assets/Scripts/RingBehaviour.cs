using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingBehaviour : MonoBehaviour
{
    [SerializeField] GameObject sceneManagerGameObject;
    SceneManager sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        sceneManagerGameObject = GameObject.Find("SceneManager");
        sceneManager = sceneManagerGameObject.GetComponent<SceneManager>();
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
}
