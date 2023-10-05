using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public GameObject backgroundMusicPlayed;
    public void PlayBackgroundMusic()
    {
        
        if (backgroundMusicPlayed != null)
        {
            AudioSource audioSource = backgroundMusicPlayed.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    public void StopBackgroundMusic()
    {
        if (backgroundMusicPlayed != null)
        {
            AudioSource audioSource = backgroundMusicPlayed.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Stop();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
