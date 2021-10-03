using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockFollow : MonoBehaviour
{
    public Transform Player;
    public float Speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 follow = Player.position;
        
        this.transform.position = Vector3.MoveTowards(this.transform.position, follow, Speed * Time.deltaTime);
    }
}

