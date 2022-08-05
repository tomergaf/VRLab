using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnHit : MonoBehaviour
{
    public PlayQuickSound sound;
    public float volumeModifier;
    // Start is called before the first frame update
    void OnAwake()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.CompareTag("Player"))) { 
            sound.volume = volumeModifier * (collision.relativeVelocity.magnitude);
            sound.Play();
        }
    }
}
