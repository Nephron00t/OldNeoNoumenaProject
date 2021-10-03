using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoFollow : MonoBehaviour
{
    private GameObject protoRemote;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
            r.enabled = false;
    }

    void Update()
    {

        Vector3 follow = protoRemote.transform.position;
        this.transform.position = Vector3.MoveTowards(this.transform.position, follow, Speed * Time.deltaTime);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (protoRemote == null)
        {
            protoRemote = GameObject.Find("ProtoGuattari(Clone)");
        }
        if (protoRemote != null)
        {
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
                r.enabled = true;
        }

    }
}
