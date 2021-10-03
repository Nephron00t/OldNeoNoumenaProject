using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentPosition : MonoBehaviour
{
    public StayInRadiusContentBehavior contentRadius;
    public Transform contentTransform;
    private Vector3 contentPosition;

    void Update()
    {
        contentPosition = contentTransform.position;
        contentRadius.center = contentPosition;
    }
}
