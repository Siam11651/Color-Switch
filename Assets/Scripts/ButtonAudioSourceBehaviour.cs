using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudioSourceBehaviour : MonoBehaviour
{
    private int initialScene;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        initialScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        audioSource = GetComponent<AudioSource>();

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        int nowScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        if(nowScene != initialScene && !audioSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
