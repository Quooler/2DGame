using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenLogic : MonoBehaviour
{

    [SerializeField]
    LevelLogic levelLogic;

    [SerializeField]
    GameObject enterEasing;
    [SerializeField]
    GameObject exitEasing;

    [Header("Scenes")]
    const int titleScene = 1;
    const int gameplayScene = 2;
    const int endScene = 3;

    bool isMenu; 

    void Start()
    {
        levelLogic = GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelLogic>();
        levelLogic.PlayEnd();
        enterEasing.SetActive(true); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            exitEasing.SetActive(true);
            isMenu = true; 
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            exitEasing.SetActive(true);
            isMenu = false; 
        }
    }

    public void LoadScene()
    {
        levelLogic.Stop();

        if (isMenu)
        {
            levelLogic.StartLoad(titleScene);
        }
        else
        {
            levelLogic.StartLoad(gameplayScene);
        }
    }
}
