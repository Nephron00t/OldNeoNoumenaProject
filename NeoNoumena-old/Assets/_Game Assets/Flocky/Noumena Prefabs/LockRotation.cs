using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    // Start is called before the first frame update

    Transform t; 
    public float fixedrotation = 5;


    void Start()
    {
        t = transform;
    }

    // Update is called once per frame
    void Update()
    {
        t.eulerAngles = new Vector3(fixedrotation, fixedrotation, fixedrotation);
    }
}
