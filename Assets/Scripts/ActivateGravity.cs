using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGravity : MonoBehaviour
{
    private float TimeLeft = 0.5f;
    private bool HasAlreadyActivated = false;
    private void Update()
    {
        if(TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
        }
        else
        {
            if(HasAlreadyActivated == false) 
            {
                ActivateGravityOnActivate();
            }
            HasAlreadyActivated = true;
        }
    }
    public void ActivateGravityOnActivate()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }
}
