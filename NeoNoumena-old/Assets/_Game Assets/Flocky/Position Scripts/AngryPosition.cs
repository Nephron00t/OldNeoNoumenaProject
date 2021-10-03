using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryPosition : MonoBehaviour
{
    public StayInRadiusAngryBehavior angryRadius;
    public Transform angryTransform;
    private Vector3 angryPosition;

    void Update()
    {
        angryPosition = angryTransform.position;
        angryRadius.center = angryPosition;
    }
}
