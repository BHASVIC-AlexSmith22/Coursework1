using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody body;
    public float countdownOne;
    public int SideSpeed = 300;
    public int ForwardVelocity = 8;
    public int JumpHeight = 200;
    public float DuckHeight = 0.5f;

    public void Death()
    {
        Debug.Log("Death called");
        transform.position = new Vector3(0, 1, 0);
    }
    public void Jump()
    {
        body.AddForce(new Vector3(0, JumpHeight, 0));
        countdownOne = 1;
        Invoke("WaitOneSec", 1);
    }
    public void WaitOneSec() {
        countdownOne = 0;
        
    }

    public void UnDuck() {
        transform.localScale = transform.localScale * 2f;
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
            body.AddForce(new Vector3(SideSpeed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey("a"))
        {
            body.AddForce(new Vector3(-SideSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey("w") & countdownOne ==0 & body.transform.position.y >= 1)
        {
            Jump();
           
        }
        if (Input.GetKey("s") & countdownOne == 0) {
           transform.localScale = transform.localScale * DuckHeight;
            countdownOne = 1;
            Invoke("UnDuck", 0.5f);
            Invoke("WaitOneSec",1);
         
        }
        //Constant foward movement
        transform.position += transform.forward * (ForwardVelocity * Time.deltaTime);
    }

}
