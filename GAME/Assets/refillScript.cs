using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refillScript : MonoBehaviour
{
    public MeshRenderer liquidRenderer;
    private Material liquidMat;
    
    public GameObject bottomOfCup;

    public bool refill = false;

    public float refillIncrement = 0.01f;
    public float startFillOffset = -0.2f;

    private void Start()
    {
        liquidMat = liquidRenderer.material;
        liquidMat.SetFloat("_GlobalFill", bottomOfCup.transform.position.y + startFillOffset);
    }

    private void Update()
    {
        if (refill)
        {
            var currentFill = liquidMat.GetFloat("_GlobalFill");
            
            liquidMat.SetFloat("_GlobalFill", (currentFill + (refillIncrement * Time.deltaTime)));
            
            Debug.Log(currentFill);
        }
    }
}
