using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refillScript : MonoBehaviour
{
    public Material teaMaterial;
    public Material milkMaterial;
    
    public GameObject teaPrefab;
    public GameObject milkPrefab;
    
    public MeshRenderer liquidRenderer;
    private Material liquidMat;
    
    public GameObject bottomOfCup;
    
    public bool isTea = false;
    public bool isMilk = false;
    
    public float refillIncrement = 0.01f;
    public float startFillOffset = -0.2f;
    
    public float colorLerpSpeed = 0.5f; // tweak as desired

    // Internal tracking
    private bool colorSet = false;         
    private Color currentColor;            
    private Color targetColor;             
    private bool isMixing = false;         

    private Color teaColor; 
    private Color milkColor;

    private void Start()
    {
        // Grab the material actually in use (clone of the original)
        liquidMat = liquidRenderer.material;

        // Initialize the fill level
        liquidMat.SetFloat("_GlobalFill", bottomOfCup.transform.position.y + startFillOffset);

        // Cache each liquid's color from its prefab's material
        teaColor = teaMaterial.color;
        milkColor = milkMaterial.color;
        
        currentColor = Color.clear; 
        liquidMat.SetColor("_Color", currentColor);
    }

    private void Update()
    {
        // Update the fill level if either liquid is being poured
        if (isTea || isMilk)
        {
            float currentFill = liquidMat.GetFloat("_GlobalFill");
            liquidMat.SetFloat("_GlobalFill", currentFill + (refillIncrement * Time.deltaTime));
        }

        // If Tea is turned on and no color has been set yet, set entire liquid to Tea color immediately
        if (isTea && !colorSet)
        {
            currentColor = teaColor;
            liquidMat.SetColor("_Color", currentColor);
            colorSet = true;
        }
        // If Milk is turned on and no color has been set yet, set entire liquid to Milk color immediately
        else if (isMilk && !colorSet)
        {
            currentColor = milkColor;
            liquidMat.SetColor("_Color", currentColor);
            colorSet = true;
        }
        
        if (colorSet)
        {
            // If Milk starts pouring but we initially poured Tea
            if (isMilk && !isTea)
            {
                // Blend from currentColor to 50/50 mix of currentColor & milkColor
                targetColor = (currentColor + milkColor) * 0.5f;
                isMixing = true;
            }
            // If Tea starts pouring but we initially poured Milk
            if (isTea && !isMilk)
            {
                // Blend from currentColor to 50/50 mix of currentColor & teaColor
                targetColor = (currentColor + teaColor) * 0.5f;
                isMixing = true;
            }
        }

        // Perform the interpolation if isMixing is true
        if (isMixing)
        {
            currentColor = Color.Lerp(currentColor, targetColor, colorLerpSpeed * Time.deltaTime);
            liquidMat.SetColor("_Color", currentColor);

            // If close enough to target, we can stop mixing
            if (Vector4.Distance(currentColor, targetColor) < 0.01f)
            {
                currentColor = targetColor; // Snap to final
                liquidMat.SetColor("_Color", currentColor);
                isMixing = false;
            }
        }
    }
}
