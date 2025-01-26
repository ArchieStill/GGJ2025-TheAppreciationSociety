using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refillScript : MonoBehaviour
{
    public Material teaMaterial;
    public Material milkMaterial;
    
    [Header("Prefabs that have the materials/colors")]
    public GameObject teaPrefab;
    public GameObject milkPrefab;

    [Header("Liquid Renderer & Material")]
    public MeshRenderer liquidRenderer;
    private Material liquidMat;

    [Header("Cup Information")]
    public GameObject bottomOfCup;

    [Header("Booleans to simulate pouring")]
    public bool isTea = false;
    public bool isMilk = false;

    [Header("Liquid Filling")]
    public float refillIncrement = 0.01f;
    public float startFillOffset = -0.2f;

    [Header("Color Mixing")]
    public float colorLerpSpeed = 0.5f; // tweak as desired

    // Internal tracking
    private bool colorSet = false;         // Has the liquid color been set yet?
    private Color currentColor;            // The current color of our liquid
    private Color targetColor;             // The color we want to move towards
    private bool isMixing = false;         // Are we currently blending colors?

    private Color teaColor; 
    private Color milkColor;

    private void Start()
    {
        // Grab the material actually in use (clone of the original)
        liquidMat = liquidRenderer.material;

        // Initialize the fill level
        liquidMat.SetFloat("_GlobalFill", bottomOfCup.transform.position.y + startFillOffset);

        // Cache each liquid's color from its prefab's material
        // You can use `.sharedMaterial` if you don’t want to create an extra instance
        teaColor = teaMaterial.color;
        milkColor = milkMaterial.color;

        // Just to be safe, let's start currentColor as transparent or something
        // Then once we detect tea or milk, we set it properly
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

        // 1) If Tea is turned on and no color has been set yet, set entire liquid to Tea color immediately
        if (isTea && !colorSet)
        {
            currentColor = teaColor;
            liquidMat.SetColor("_Color", currentColor);
            colorSet = true;
        }
        // 2) If Milk is turned on and no color has been set yet, set entire liquid to Milk color immediately
        else if (isMilk && !colorSet)
        {
            currentColor = milkColor;
            liquidMat.SetColor("_Color", currentColor);
            colorSet = true;
        }
        // 3) If we have already set a color (meaning we poured something first),
        //    but then a second liquid is being poured, start a color blend.

        // Example: If we poured Tea first, and now Milk is set true,
        // we can blend from currentColor to a "mixed" color.
        
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
