using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject waterParticle;
    public GameObject spawnPoint;
    
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.25f)
        {
            timer = 0;
            Instantiate(waterParticle, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }
}
