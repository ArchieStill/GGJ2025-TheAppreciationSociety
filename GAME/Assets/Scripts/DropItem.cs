using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject Boba;
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public GameObject Spawn4;
    public GameObject Spawn5;

    private Rigidbody bobaBody;

    private void Start()
    {
        bobaBody = Boba.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            int SpawnToChoose = (Random.Range(1, 6));
            Debug.Log(SpawnToChoose);
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
    }
}
