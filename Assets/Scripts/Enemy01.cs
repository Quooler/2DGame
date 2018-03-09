using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Enemy01 : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            StatsManager.playerPoints = 0; 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
