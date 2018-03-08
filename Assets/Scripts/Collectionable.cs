using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectionable : MonoBehaviour
{
    [SerializeField]
    int myValue; 

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("HELO");

        if (other.CompareTag("Player"))
        {
            Debug.Log("HELO"); 
            StatsManager.playerPoints += myValue; 
            gameObject.SetActive(false); 
        }
    }
}
