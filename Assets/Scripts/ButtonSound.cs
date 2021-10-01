using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonSoundPlay);
    }

    private void Update()
    {
        
    }

    void ButtonSoundPlay()
    { 
        if(audioSource != null)
        {
            audioSource.Play();
        }
    }
}
