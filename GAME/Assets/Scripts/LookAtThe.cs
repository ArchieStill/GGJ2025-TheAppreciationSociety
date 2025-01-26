using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class LookAtThe : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        PlayAnimation();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("hello");
            LookUp();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            print("hello");
            LookDown();
        }
    }

    private void LateUpdate()
    {
        anim.SetInteger("Direction", 0);
    }

    private void LookUp()
    {
        anim.SetInteger("Direction", 1);

    }

    private void LookDown()
    {
        anim.SetInteger("Direction", -1);
    }
}
