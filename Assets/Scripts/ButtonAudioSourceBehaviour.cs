using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudioSourceBehaviour : MonoBehaviour
{
    private int initialScene;
    private AudioSource audioSource;
    private bool dead;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        initialScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        audioSource = GetComponent<AudioSource>();

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        int nowScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        if(!audioSource.isPlaying)
        {
            if(nowScene != initialScene || dead)
            {
                Destroy(gameObject);
            }
        }
    }

    public bool isDead
    {
        get
        {
            return dead;
        }

        set
        {
            dead = value;
        }
    }
}
