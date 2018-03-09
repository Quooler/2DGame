using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System; 

public class Enemy01 : MonoBehaviour
{
    Transform[] pathPoints;
    bool isIndexing;
    int index; 

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, pathPoints[index].position, Time.deltaTime);

        if(transform.position == pathPoints[index].position)
        {
            isIndexing = !isIndexing;
            index = Convert.ToInt32(isIndexing);        
        }
    }

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
