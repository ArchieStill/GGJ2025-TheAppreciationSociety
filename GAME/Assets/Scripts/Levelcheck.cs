using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelcheck : MonoBehaviour
{

    private int Fillquant;
    private bool Fillbool;

    void OnTriggerEnter(Collider other)
    {
        Fillquant++;
    }

    void OnTriggerExit(Collider other)
    {
        Fillquant--;
    }

    public bool FillStatus()
    {
        if (Fillquant >= 1)
        {
            Fillbool = true;
        }
        else {Fillbool = false;}
        return Fillbool;
    }
}
