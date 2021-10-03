using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyPosition : MonoBehaviour
{

    public StayInRadiusHappyBehavior happyradius;
    public Transform HappyTramsform;
    private Vector3 happyposition; 

    void Update()
    {
        happyposition = HappyTramsform.position;
        happyradius.center = happyposition;
    }
}
