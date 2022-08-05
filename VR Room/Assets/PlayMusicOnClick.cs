using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnClick : MonoBehaviour
{

    public AudioSource audioSource;
    // Start is called before the first frame update
    
    public void TogglePlayPause()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else {
            audioSource.Play();
        }
    }
    void OnAwake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
