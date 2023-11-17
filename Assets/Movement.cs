using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody body;
    public float jumpcountdown;
    public void Jump()
    {
        body.AddForce(new Vector3(0, 200f, 0));
        jumpcountdown = 1;
        Invoke("WaitOneSec", 1);
    }
    public void WaitOneSec() {
        jumpcountdown = 0;
    
    }
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            body.AddForce(new Vector3(2, 0, 0));
        }

        if (Input.GetKey("a"))
        {
            body.AddForce(new Vector3(-2, 0, 0));
        }
        if (Input.GetKey("w") & jumpcountdown ==0)
        {
            Jump();
           
        }
        //Constant foward movement
        transform.position += transform.forward * (8 * Time.deltaTime);
    }

}
