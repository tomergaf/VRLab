using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnHit : MonoBehaviour
{
    public AudioSource sound;
    public Collider cd;
    public float volumeModifier;
    public Rigidbody rb;
    // Start is called before the first frame update
    void OnAwake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.CompareTag("Player"))) { 
            sound.volume = volumeModifier * rb.velocity.magnitude;
            sound.PlayOneShot(sound.clip);
        }
    }
}
