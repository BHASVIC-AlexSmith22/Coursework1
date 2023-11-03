using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            body.AddForce(new Vector3(5, 0, 0));
        }

        if (Input.GetKey("a"))
        {
            body.AddForce(new Vector3(-5, 0, 0));
        }
        if (Input.GetKey("w"))
        {
            body.AddForce(new Vector3(0, 3, 0));
            
        }

        body.AddForce(new Vector3(0, 0, 3));
    }

}
