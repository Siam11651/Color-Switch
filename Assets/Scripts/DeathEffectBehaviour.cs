using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffectBehaviour : MonoBehaviour
{
    [SerializeField] ParticleSystem[] balls;
    SceneManager sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();

        foreach(ParticleSystem ball in balls)
        {
            ball.Play();
        }

        StartCoroutine(CheckBalls());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CheckBalls()
    {
        while(true)
        {
            yield return null;

            bool allStopped = true;

            foreach(ParticleSystem ball in balls)
            {
                if(ball.isPlaying)
                {
                    allStopped = false;

                    break;
                }
            }

            if(allStopped)
            {
                break;
            }
        }

        GameManager.GameOver(sceneManager);
    }
}
