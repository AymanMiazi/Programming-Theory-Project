using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sedan : CarController
{

    [SerializeField] private GameObject trail;
    private bool isTrailActive = false;
    
    protected override void ActivateSpecial()
    {
        if(!isTrailActive)
        {
            trail.SetActive(true);
            isTrailActive = true;
        }
        else
        {
            trail.SetActive(false);
            isTrailActive = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ActivateSpecial();
        }
    }
    
}
