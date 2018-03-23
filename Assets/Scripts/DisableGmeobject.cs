using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGmeobject : MonoBehaviour
{
    [SerializeField]
    GameObject other;

    public void Disable()
    {
        other.SetActive(false); 
    }
}
