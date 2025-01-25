using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientCheck : MonoBehaviour
{
    private CapsuleCollider CupTrigger;


    void Start()
    {
        CupTrigger = GetComponent<CapsuleCollider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Boba":
                Debug.Log("boba");
                break;
            case "Jelly":
                Debug.Log("jelly");
                break;
            case "Tea":
                Debug.Log("tea");
                break;
            case "Milk":
                Debug.Log("milk");
                break;
            case "Syrup":
                Debug.Log("syrup");
                break;
        }
    }
}
