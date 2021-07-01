using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RibbonBehavior : MonoBehaviour
{
    [SerializeField] GameObject thisPrefab;
    [SerializeField] Transform endTransform;
    [SerializeField] float speed;
    Rigidbody2D rb2D;
    GameObject parent;
    bool copied;

    // Start is called before the first frame update
    void Start()
    {
        copied = false;
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(speed, 0);
        parent = transform.parent.gameObject;
    }

    void Spawn()
    {
        GameObject newGameObject = Instantiate(thisPrefab);
        newGameObject.name = name;
        newGameObject.transform.SetParent(transform.parent);
        newGameObject.transform.position = endTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!copied && transform.position.x > 2.5f)
        {
            Spawn();

            copied = true;
        }

        if(endTransform.position.x > 2.5f)
        {
            Destroy(gameObject);
        }
    }
}
