using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fillcheck : MonoBehaviour
{
    public MeshRenderer liquidRenderer;
    private Material liquidMat;

    private bool Filled;

    private void Awake() 
    {
        liquidMat = liquidRenderer.material;
    }

    public bool Checkfill()
    {
        // filled = 1.238
        //empty = -2.084
        float currentFill = liquidMat.GetFloat("_GlobalFill");
        Filled = false;
        if (currentFill >= -3f)
        {
            Filled = true;
        }
        return Filled;
    }
}
