using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillingScript : MonoBehaviour
{
    public bool isSpilling = false;
    
    private ParticleSystem spillingSys;
    
    private void Awake()
    { 
        spillingSys = this.gameObject.GetComponentInChildren<ParticleSystem>();
        spillingSys.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpilling)
        {
            spillingSys.Play();
        }
        else if(spillingSys)
        {
            spillingSys.Stop();
        }
    }
}
