using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectionable : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer myRenderer;
    [SerializeField]
    AudioSource myAudioSource;
    [SerializeField]
    int myValue;
    bool isPlaying;

    AudioClip clip; 

    void Update()
    {
        if (isPlaying)
        {
            if (!myAudioSource.isPlaying)
            {
                gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StatsManager.playerPoints += myValue;
            myAudioSource.PlayOneShot(myAudioSource.clip);
            myRenderer.enabled = false; 
            isPlaying = true; 
        }
    }
}
