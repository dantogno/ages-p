using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private AudioSource audioSource;
    private SphereCollider sphereCollider;
  

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(SphereCollider collision) // if the player collides with object, the object is destroyed.
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject, audioSource.clip.length);
            sphereCollider.enabled = false;
            audioSource.Play();
        }

    }
}
