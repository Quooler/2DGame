using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterInput : MonoBehaviour
{
    [SerializeField]
    LevelLogic levelLogic;

    [SerializeField]
    GameObject easing; 

    [Header("Scenes")]
    const int titleScene = 1;
    const int gameplayScene = 2;
    const int endScene = 3;

    void Start()
    {
        levelLogic = GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelLogic>();
    }

    void Update ()
    {
		if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.S))
        {
            easing.SetActive(true);
           // levelLogic.StartLoad(gameplayScene); 
        }
	}

    public void StartLoad()
    {
        levelLogic.StartLoad(gameplayScene);
    }
}
