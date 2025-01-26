using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    public bool isSpawning = false;
    
    public GameObject objectToSpawn;
    public GameObject spawnPoint;
    public float interval = 0.25f;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning) return;

        timer += Time.deltaTime;

        if (timer > interval)
        {
            timer = 0;
            Instantiate(objectToSpawn, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }
}
