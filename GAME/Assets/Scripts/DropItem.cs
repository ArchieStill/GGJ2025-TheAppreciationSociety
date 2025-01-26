using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject Trigger;
    public GameObject Boba;
    public GameObject Jelly;
    public GameObject Tea;

    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public GameObject Spawn4;
    public GameObject Spawn5;
    public GameObject CanPanel;

    public GameObject DropDisplay;
    private bool WarningOn;
    private GameObject[] SpawnArray = new GameObject[5];

    private bool CanUse = true;
    private float InactiveTime = 4.0f;
    private Rigidbody bobaBody;
    private Rigidbody jellyBody;
    private Rigidbody teaBody;

    private void Start()
    {
        SpawnArray[0] = Spawn1;
        SpawnArray[1] = Spawn2;
        SpawnArray[2] = Spawn3;
        SpawnArray[3] = Spawn4;
        SpawnArray[4] = Spawn5;
        bobaBody = Boba.GetComponent<Rigidbody>();
        jellyBody = Jelly.GetComponent<Rigidbody>();
        teaBody = Tea.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && CanUse)
        {
            DropBoba();
            CanUse = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && CanUse)
        {
            DropJelly();
            CanUse = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && CanUse)
        {
            DropTea();
            CanUse = false;
        }

        if (!CanUse)
        {
            InactiveTime -= Time.deltaTime;
            CanPanel.SetActive(true);
        }
        if (InactiveTime <= 2 && WarningOn)
        {
            DropDisplay.GetComponent<Dropsignals>().HideWarning();
            WarningOn = false;
        }
        if (InactiveTime <= 0.0f)
        {
            CanUse = true;
            CanPanel.SetActive(false);
            InactiveTime = 4.0f;
        }
    }
    
    private void DropBoba()
    {
        int SpawnToChoose = (Random.Range(1, 6));
        DropDisplay.GetComponent<Dropsignals>().OnDrop(SpawnArray[SpawnToChoose-1].transform.position.x, "Boba");
        WarningOn = true;
        var force = new Vector3(Random.Range(1, 6), 1, Random.Range(1, 6));
        bobaBody.AddForce(force);
        switch (SpawnToChoose)
        {
            case 1:
                for (int i = 0; i < 15; i++)
                    Instantiate(Boba, new Vector3(Spawn1.transform.position.x, Spawn1.transform.position.y + i, Spawn1.transform.position.z), Quaternion.identity);
                break;
            case 2:
                for (int i = 0; i < 15; i++)
                    Instantiate(Boba, new Vector3(Spawn2.transform.position.x, Spawn2.transform.position.y + i, Spawn2.transform.position.z), Quaternion.identity);
                break;
            case 3:
                for (int i = 0; i < 15; i++)
                    Instantiate(Boba, new Vector3(Spawn3.transform.position.x, Spawn3.transform.position.y + i, Spawn3.transform.position.z), Quaternion.identity);
                break;
            case 4:
                for (int i = 0; i < 15; i++)
                    Instantiate(Boba, new Vector3(Spawn4.transform.position.x, Spawn4.transform.position.y + i, Spawn4.transform.position.z), Quaternion.identity);
                break;
            case 5:
                for (int i = 0; i < 15; i++)
                    Instantiate(Boba, new Vector3(Spawn5.transform.position.x, Spawn5.transform.position.y + i, Spawn5.transform.position.z), Quaternion.identity);
                break;
            default:
                break;
        }
    }

    private void DropJelly()
    {
        int SpawnToChoose = (Random.Range(1, 6));
        DropDisplay.GetComponent<Dropsignals>().OnDrop(SpawnArray[SpawnToChoose-1].transform.position.x, "Jelly");
        WarningOn = true;
        var force = new Vector3(Random.Range(1, 6), 1, Random.Range(1, 6));
        jellyBody.AddForce(force);
        switch (SpawnToChoose)
        {
            case 1:
                for (int i = 0; i < 10; i++)
                    Instantiate(Jelly, new Vector3(Spawn1.transform.position.x, Spawn1.transform.position.y + i, Spawn1.transform.position.z), Quaternion.identity);
                break;
            case 2:
                for (int i = 0; i < 10; i++)
                    Instantiate(Jelly, new Vector3(Spawn2.transform.position.x, Spawn2.transform.position.y + i, Spawn2.transform.position.z), Quaternion.identity);
                break;
            case 3:
                for (int i = 0; i < 10; i++)
                    Instantiate(Jelly, new Vector3(Spawn3.transform.position.x, Spawn3.transform.position.y + i, Spawn3.transform.position.z), Quaternion.identity);
                break;
            case 4:
                for (int i = 0; i < 10; i++)
                    Instantiate(Jelly, new Vector3(Spawn4.transform.position.x, Spawn4.transform.position.y + i, Spawn4.transform.position.z), Quaternion.identity);
                break;
            case 5:
                for (int i = 0; i < 10; i++)
                    Instantiate(Jelly, new Vector3(Spawn5.transform.position.x, Spawn5.transform.position.y + i, Spawn5.transform.position.z), Quaternion.identity);
                break;
            default:
                break;
        }
    }

    private void DropTea()
    {
        int SpawnToChoose = (Random.Range(1, 6));
        DropDisplay.GetComponent<Dropsignals>().OnDrop(SpawnArray[SpawnToChoose - 1].transform.position.x, "Tea");
        WarningOn = true;
        var force = new Vector3(Random.Range(1, 6), 1, Random.Range(1, 6));
        teaBody.AddForce(force);
        switch (SpawnToChoose)
        {
            case 1:
                Instantiate(Tea, new Vector3(Spawn1.transform.position.x, Spawn1.transform.position.y, Spawn1.transform.position.z), Quaternion.identity);
                break;
            case 2:
                Instantiate(Tea, new Vector3(Spawn2.transform.position.x, Spawn2.transform.position.y, Spawn2.transform.position.z), Quaternion.identity);
                break;
            case 3:
                Instantiate(Tea, new Vector3(Spawn3.transform.position.x, Spawn3.transform.position.y, Spawn3.transform.position.z), Quaternion.identity);
                break;
            case 4:
                Instantiate(Tea, new Vector3(Spawn4.transform.position.x, Spawn4.transform.position.y, Spawn4.transform.position.z), Quaternion.identity);
                break;
            case 5:
                Instantiate(Tea, new Vector3(Spawn5.transform.position.x, Spawn5.transform.position.y, Spawn5.transform.position.z), Quaternion.identity);
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == Trigger)
        {
            bobaBody.isKinematic = true;
            jellyBody.isKinematic = true;
            Debug.Log("TRIGGER");
        }
    }
}
