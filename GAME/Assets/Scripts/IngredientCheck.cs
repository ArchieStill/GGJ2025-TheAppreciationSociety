using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientCheck : MonoBehaviour
{
    private CapsuleCollider CupTrigger;

    private bool Hasboba;
    private bool Hasjelly;
    private bool Hastea;
    private bool Hasmilk;
    private bool Hassyrup;
    private bool[] Hascontents = new bool[5];

    void Start()
    {
        Hascontents[0] = Hasboba;
        Hascontents[1] = Hasjelly;
        Hascontents[2] = Hastea;
        Hascontents[3] = Hasmilk;
        Hascontents[4] = Hassyrup;
        CupTrigger = GetComponent<CapsuleCollider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Boba":
                Debug.Log("boba");
                Hasboba = true;
                break;
            case "Jelly":
                Debug.Log("jelly");
                Hasjelly = true;
                break;
            case "Tea":
                Debug.Log("tea");
                Hastea = true;
                break;
            case "Milk":
                Debug.Log("milk");
                Hasmilk = true;
                break;
            case "Syrup":
                Debug.Log("syrup");
                Hassyrup = true;
                break;
        }
    }

    public bool[] ReturnContents()
    {
        Hascontents[0] = Hasboba;
        Hascontents[1] = Hasjelly;
        Hascontents[2] = Hastea;
        Hascontents[3] = Hasmilk;
        Hascontents[4] = Hassyrup;
        return Hascontents;
    }
}
