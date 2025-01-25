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

    void Start()
    {
        Self = this.transform;
        segment = 685 / 4.5f;
    }

    public void OnDrop(float DropPlace, string DropType)
    {
        float IconPosition = (DropPlace * segment) + 685;
        ChildNumber = Array.IndexOf(ingredients, DropType);
        Self.GetChild(ChildNumber).gameObject.SetActive(true);
        Transform Chipos = Self.GetChild(ChildNumber).transform;
        Self.GetChild(ChildNumber).transform.position = new Vector3(IconPosition, Chipos.position.y, Chipos.position.z);
    }

    public void HideWarning()
    {
        Debug.Log("xgfdcmhvjkulio;p'okjiukgyjtfmhgrndesbzbfxgchvjbyikuoip9u8yt,rfmgndesfbfxghjhk");
        Self.GetChild(ChildNumber).gameObject.SetActive(false);
    }
}
