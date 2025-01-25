using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject Boba;
    public GameObject Jelly;
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public GameObject Spawn4;
    public GameObject Spawn5;

    private Rigidbody bobaBody;
    private Rigidbody jellyBody;

    private void Start()
    {
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
        var force = new Vector3(Random.Range(1, 6), 1, Random.Range(1, 6));
        bobaBody.AddForce(force);
        switch (SpawnToChoose)
        {
            case 1:
                Instantiate(Boba, Spawn1.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(Boba, Spawn2.transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(Boba, Spawn3.transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(Boba, Spawn4.transform.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(Boba, Spawn5.transform.position, Quaternion.identity);
                break;
            default:
                break;
        }
    }

    private void DropJelly()
    {
        int SpawnToChoose = (Random.Range(1, 6));
        var force = new Vector3(Random.Range(1, 6), 1, Random.Range(1, 6));
        jellyBody.AddForce(force);
        switch (SpawnToChoose)
        {
            case 1:
                Instantiate(Jelly, Spawn1.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(Jelly, Spawn2.transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(Jelly, Spawn3.transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(Jelly, Spawn4.transform.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(Jelly, Spawn5.transform.position, Quaternion.identity);
                break;
            default:
                break;
        }
    }
}
