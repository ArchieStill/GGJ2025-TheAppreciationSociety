using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringSetter : MonoBehaviour
{
    public float Spring = 100;
    public float Damper = 0.2f;
    public float MinDistance = 0;
    public float MaxDistance = 0;
    public float Tolerance = 0.025f;
    public float MassScale = 1;
    public float ConnectedMassScale = 1;
    
    private SpringJoint[] springJoints;

    private void Awake()
    {
        springJoints = GetComponents<SpringJoint>();
    }

    private void Start()
    {
        foreach (var joint in springJoints)
        {
            joint.spring = Spring;
            joint.damper = Damper;
            joint.minDistance = MinDistance;
            joint.maxDistance = MaxDistance;
            joint.tolerance = Tolerance;
            joint.massScale = MassScale;
            joint.connectedMassScale = ConnectedMassScale;
        }
    }
}
