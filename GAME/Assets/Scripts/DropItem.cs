using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject Trigger;
    public GameObject Boba;
    public GameObject Jelly;
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public GameObject Spawn4;
    public GameObject Spawn5;

    public GameObject DropDisplay;

    private GameObject[] SpawnArray = new GameObject[5];
    private Rigidbody bobaBody;
    private Rigidbody jellyBody;

    private void Start()
    {
        SpawnArray[0] = Spawn1;
        SpawnArray[1] = Spawn2;
        SpawnArray[2] = Spawn3;
        SpawnArray[3] = Spawn4;
        SpawnArray[4] = Spawn5;
        bobaBody = Boba.GetComponent<Rigidbody>();
        jellyBody = Jelly.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            DropBoba();
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            DropJelly();
    }
    

    private void DropBoba()
    {
        int SpawnToChoose = (Random.Range(1, 6));
        DropDisplay.GetComponent<Dropsignals>().OnDrop(SpawnArray[SpawnToChoose-1].transform, "Boba");
        var force = new Vector3(Random.Range(1, 6), 1, Random.Range(1, 6));
        bobaBody.AddForce(force);
        switch (SpawnToChoose)
        {
            case 1:
                for (int i = 0; i < 20; i++)
                    Instantiate(Boba, new Vector3(Spawn1.transform.position.x, Spawn1.transform.position.y + i, Spawn1.transform.position.z), Quaternion.identity);
                break;
            case 2:
                for (int i = 0; i < 20; i++)
                    Instantiate(Boba, new Vector3(Spawn2.transform.position.x, Spawn2.transform.position.y + i, Spawn2.transform.position.z), Quaternion.identity);
                break;
            case 3:
                for (int i = 0; i < 20; i++)
                    Instantiate(Boba, new Vector3(Spawn3.transform.position.x, Spawn3.transform.position.y + i, Spawn3.transform.position.z), Quaternion.identity);
                break;
            case 4:
                for (int i = 0; i < 20; i++)
                    Instantiate(Boba, new Vector3(Spawn4.transform.position.x, Spawn4.transform.position.y + i, Spawn4.transform.position.z), Quaternion.identity);
                break;
            case 5:
                for (int i = 0; i < 20; i++)
                    Instantiate(Boba, new Vector3(Spawn5.transform.position.x, Spawn5.transform.position.y + i, Spawn5.transform.position.z), Quaternion.identity);
                break;
            default:
                break;
        }
    }

    private void DropJelly()
    {
        int SpawnToChoose = (Random.Range(1, 6));
        DropDisplay.GetComponent<Dropsignals>().OnDrop(SpawnArray[SpawnToChoose].transform, "Jelly");
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