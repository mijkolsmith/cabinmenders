using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip _bg1;

    [SerializeField]
    private AudioClip _bg2;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            audioSource.clip = _bg1;
            if(!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            audioSource.clip = _bg2;
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
    }
}
