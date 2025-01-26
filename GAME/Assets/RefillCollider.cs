using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RefillCollider : MonoBehaviour
{
    public refillScript refillScr;

    public float timerThreshold = 0.15f;
    private float timer = 0;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Milk"))
        {
            refillScr.isMilk = true;
            Destroy(other.gameObject);
            timer = 0;
        }
        else if (other.CompareTag("Tea"))
        {
            refillScr.isTea = true;
            Destroy(other.gameObject);
            timer = 0;
        }
        else if (other.CompareTag("Syrup"))
        {
            refillScr.isSyrup = true;
            Destroy(other.gameObject);
            timer = 0;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > timerThreshold)
        {
            refillScr.isMilk = false;
            refillScr.isTea = false;
            refillScr.isSyrup = false;
        }
    }
}
