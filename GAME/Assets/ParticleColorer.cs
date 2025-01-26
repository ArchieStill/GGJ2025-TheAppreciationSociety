using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleColorer : MonoBehaviour
{
    public MeshRenderer liquidRenderer;
    private Material liquidMat;
    
    private List<ParticleSystem> particles;

    private int counter = 0;

    void Start()
    {
        liquidMat = liquidMat = liquidRenderer.material;
        
        particles = new List<ParticleSystem>(GetComponentsInChildren<ParticleSystem>());
    }

    private void Update()
    {
        counter++;
        if (counter < 3) return;
        counter = 0;
        
        foreach (var ps in particles)
        {
            var main = ps.main;
            main.startColor = liquidMat.GetColor("_Color");;
        }
    }
}


