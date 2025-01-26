using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientCheck : MonoBehaviour
{
    private CapsuleCollider CupTrigger;

    private int Hasboba;
    private int Hasjelly;
    private int Hastea;
    private int Hasmilk;
    private int Hassyrup;
    private bool[] Hascontents = new bool[5];

    void Start()
    {
        Hascontents[0] = false;
        Hascontents[1] = false;
        Hascontents[2] = false;
        Hascontents[3] = false;
        Hascontents[4] = false;
        CupTrigger = GetComponent<CapsuleCollider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Boba":
                Hasboba++;
                break;
            case "Jelly":
                Hasjelly++;
                break;
            case "Tea":
                Hastea++;
                break;
            case "Milk":
                Hasmilk++;
                break;
            case "Syrup":
                Hassyrup++;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
            switch (other.tag)
        {
            case "Boba":
                Hasboba--;
                break;
            case "Jelly":
                Hasjelly--;
                break;
            case "Tea":
                Hastea--;
                break;
            case "Milk":
                Hasmilk--;
                break;
            case "Syrup":
                Hassyrup--;
                break;
        }
    }

    public bool[] ReturnContents()
    {
        if (Hasboba >= 1)
        {Hascontents[0] = true;}
        else {Hascontents[0] = false;}
        if (Hasjelly >= 1)
        {Hascontents[1] = true;}
        else {Hascontents[1] = false;}
        if (Hastea >= 1)
        {Hascontents[2] = true;}
        else {Hascontents[2] = false;}
        if (Hasmilk >= 1)
        {Hascontents[3] = true;}
        else {Hascontents[3] = false;}
        if (Hassyrup >= 1)
        {Hascontents[4] = true;}
        else {Hascontents[4] = false;}
        return Hascontents;
    }
}
