using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class InputManager : MonoBehaviour
{
    [SerializeField]
    Player player;
    bool isPaused;

    LevelLogic levelLogic;

    [Header("Scenes")]
    const int titleScene = 1;
    const int gameplayScene = 2;
    const int endScene = 3;

    void Start()
    {
        levelLogic = GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelLogic>();
        levelLogic.PlayGameplay();
    }

    void Update ()
    {
        if (isPaused)
        {
            PauseUpdate();
            return;
        }
        if (player != null)
        {
            InputJump();
            InputPause();
        }
	}

    public void Reset()
    {
        levelLogic.Stop(); 
        StatsManager.playerPoints = 0;
        levelLogic.StartLoad(gameplayScene); 
    }

    void PauseUpdate()
    {
        
    }

    void InputJump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
            player.JumpStart();
        }
    }

    void InputPause()
    {
        if(Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;

            if(isPaused) Time.timeScale = 0;
            else Time.timeScale = 1; 
        }
    }

    public void Exit()
    {
        Application.Quit(); 
    }
}
