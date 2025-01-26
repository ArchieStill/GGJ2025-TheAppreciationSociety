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
            Debug.Log("Spilling!");
            spillingSys.Play();
        }
        else if(spillingSys)
        {
            spillingSys.Stop();
        }
    }
}
