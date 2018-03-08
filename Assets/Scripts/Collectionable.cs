using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectionable : MonoBehaviour
{
    [SerializeField]
    int myValue; 

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StatsManager.playerPoints += myValue;
            gameObject.SetActive(false);
        }
    }
}
