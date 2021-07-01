using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraBehaviour : MonoBehaviour
{
    [SerializeField] private BallBehaviour ball;
    [SerializeField] private float e;
    private Transform ballTransform;

    // Start is called before the first frame update
    void Start()
    {
        ballTransform = ball.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if(ballTransform.position.y > transform.position.y)
        {
            transform.position += new Vector3(0,
                (ballTransform.position.y - transform.position.y) * e * Time.deltaTime,
                0);
        }
    }
}
