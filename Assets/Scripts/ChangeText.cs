using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ChangeText : MonoBehaviour
{
    [SerializeField]
    Text myText; 
	// Update is called once per frame
	void Update ()
    {
        myText.text = StatsManager.playerPoints.ToString(); 
	}
}
