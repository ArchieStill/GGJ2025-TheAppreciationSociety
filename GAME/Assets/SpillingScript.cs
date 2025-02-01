using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpillingScript : MonoBehaviour
{
    public float spillingHold = 0.05f;
    public bool isSpilling = false;
    
    private ParticleSystem spillingSys;
    private float spillingHoldTimer = 0f;
    
    private void Awake()
    { 
        spillingSys = this.gameObject.GetComponentInChildren<ParticleSystem>();
        spillingSys.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        spillingHoldTimer = spillingHoldTimer + Time.deltaTime;
        
        if (isSpilling)
        {
            spillingHoldTimer = 0;
            spillingSys.Play();
        }
        else if(!spillingSys.isStopped)
        {
            if (spillingHoldTimer > spillingHold) spillingSys.Stop();
        }
        
        Debug.Log(spillingHoldTimer);
    }
}
