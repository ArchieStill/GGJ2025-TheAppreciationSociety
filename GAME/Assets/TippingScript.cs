using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TippingScript : MonoBehaviour
{
    public MeshRenderer liquidRenderer;
    public float yOffset = 0;
    public float spillRate = 0.01f;
    public bool spilling = false;

    public float spillingOffset = 0;
    
    private List<GameObject> childrens = new List<GameObject>();
    private Material liquidMat;
    
    void Awake()
    {
        childrens.Clear();
        
        foreach (Transform child in this.transform)
        {
            childrens.Add(child.gameObject);
        }

        liquidMat = liquidRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        spillingOffset = 0;
        
        var currentFill = liquidMat.GetFloat("_GlobalFill");
        spilling = false;
        
        foreach (var tippingPoint in childrens)
        {
            var tippingParticles = tippingPoint.GetComponent<SpillingScript>();
            tippingParticles.isSpilling = false;
            
            var tippingPointY = tippingPoint.transform.position.y + yOffset;
            float tippingOffsetCurrent = (tippingPointY - currentFill) * -1;
            
            if (tippingPointY < currentFill)
            {
                spilling = true;
                tippingParticles.isSpilling = true;
                
                if (spillingOffset < tippingOffsetCurrent)
                {
                    spillingOffset = tippingOffsetCurrent;
                }
            }
        }

        if (spilling)
        {
            liquidMat.SetFloat("_GlobalFill", currentFill - (spillingOffset * spillRate));
        }
    }
}
