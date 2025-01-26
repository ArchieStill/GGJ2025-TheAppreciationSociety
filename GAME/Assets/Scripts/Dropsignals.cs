using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropsignals : MonoBehaviour
{
    private Transform IconPosition;
    private string[] ingredients = {"Boba", "Jelly", "Tea", "Milk", "Syrup"};
    private float segment;
    private Transform Self;
    private int ChildNumber;

    //quick access to own transform + calculating the ratio for screen/world space
    void Start()
    {
        Self = this.transform;
        segment = 571 / 5.5f;
    }

    //makes the warning icon appear where the ingredient is dropping
    public void OnDrop(float DropPlace, string DropType)
    {
        float IconPosition = (DropPlace * segment) + 771;
        ChildNumber = Array.IndexOf(ingredients, DropType);
        Self.GetChild(ChildNumber).gameObject.SetActive(true);
        Transform Chipos = Self.GetChild(ChildNumber).transform;
        Self.GetChild(ChildNumber).transform.position = new Vector3(IconPosition, Chipos.position.y, Chipos.position.z);
    }

    //makes the warning icon dissapear
    public void HideWarning()
    {
        Self.GetChild(ChildNumber).gameObject.SetActive(false);
    }
}
