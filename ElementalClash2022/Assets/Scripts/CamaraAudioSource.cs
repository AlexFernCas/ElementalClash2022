using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraAudioSource : MonoBehaviour
{
    public static CamaraAudioSource Instance;
    AudioSource audioSource;

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }
    public void Mute()
    {
        if (audioSource.volume == 0.05f)
        {
            audioSource.volume = 0f;
        }
        else 
        {
            audioSource.volume = 0.05f;
        }
        
    }
}
