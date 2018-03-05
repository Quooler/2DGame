using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        InputAxis();
        InputJump();
        InputPause();
	}

    void PauseUpdate()
    {
        
    }

    void InputAxis()
    {
        Vector2 axis = Vector2.zero;
        axis.x = Input.GetAxis("Horizontal");
        axis.y = Input.GetAxis("Vertical");
        player.SetAxis(axis);
    }
    void InputJump()
    {
        if(Input.GetButton("Jump"))
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
