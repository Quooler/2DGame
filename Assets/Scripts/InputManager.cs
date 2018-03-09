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

	void Update ()
    {
        if (isPaused)
        {
            PauseUpdate();
            return;
        }
        InputJump();
        InputPause();
        Reset();
	}

    void Reset()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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

}
