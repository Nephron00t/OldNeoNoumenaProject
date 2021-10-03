using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadPosition : MonoBehaviour
{
    public StayInRadiusSadBehavior sadRadius;
    public Transform sadTransform;
    private Vector3 sadPosition;

    void Update()
    {
        sadPosition = sadTransform.position;
        sadRadius.center = sadPosition;
    }
}
