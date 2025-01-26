using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float lifetime = 7f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
