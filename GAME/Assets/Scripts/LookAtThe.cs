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
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    PlayAnimation();
        //}
    }

    private void PlayAnimation()
    {
        anim.SetTrigger("Rotate");
    }
}
