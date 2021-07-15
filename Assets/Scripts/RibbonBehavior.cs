using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RibbonBehavior : MonoBehaviour
{
    public static float RIBBON_LEGNTH = 6;
    [SerializeField] GameObject thisPrefab;
    [SerializeField] Transform endTransform;
    [SerializeField] float speed;
    Rigidbody2D rb2D;
    GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(speed, 0);
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(endTransform.position.x > GameManager.WORLD_SCREEN_WIDTH)
        {
            Transform lastRibbonEnd = parent.GetComponent<RibbonSystemBehaviour>().
                GetLastRibbonEnd();
            GameObject lastRibbon = SpawnRibbon(thisPrefab, parent.transform, 
                lastRibbonEnd, name);

            parent.GetComponent<RibbonSystemBehaviour>().
                SetLastRibbonEnd(lastRibbon.GetComponent<RibbonBehavior>().GetEndTransform());
            Destroy(gameObject);
        }
    }

    public static GameObject SpawnRibbon(GameObject referencePrefab, Transform parentTransform, Transform endTransform, string name)
    {
        GameObject newGameObject = Instantiate(referencePrefab);
        newGameObject.name = name;
        newGameObject.transform.SetParent(parentTransform);
        newGameObject.transform.position = endTransform.position;

        return newGameObject;
    }

    public Transform GetEndTransform()
    {
        return endTransform;
    }
}
