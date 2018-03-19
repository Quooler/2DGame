using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System; 

public class Enemy01 : MonoBehaviour
{
    [SerializeField]
    Transform[] pathPoints;
    bool isIndexing;

    [SerializeField]
    float range;

    int index;
    [SerializeField]
    float velocity;

    void Update()
    {
        if(pathPoints.Length != 0)
        {
            transform.position = Vector3.Lerp(transform.position, pathPoints[index].position, Time.deltaTime * velocity);

            if(Vector3.Distance(transform.position, pathPoints[index].position) < range)
            {
                isIndexing = !isIndexing;
                index = Convert.ToInt32(isIndexing);
            }

            if(pathPoints[index].position.x < transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1); 
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
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
