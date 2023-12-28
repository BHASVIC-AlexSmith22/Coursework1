using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody body;
    Speedboostblock SpeedReset;
    public float countdownOne;
    public int SideSpeed = 300;
    public int ForwardVelocity = 8;
    public int JumpHeight = 200;
    public float DuckHeight = 0.5f;
    public int Switcheroo;
    public void Death()
    {
        Debug.Log("Death called");
        transform.position = new Vector3(0, 1, 0);
        body.velocity = Vector3.zero;
        DuckHeight = 0.5f;
        JumpHeight = 200;
        ForwardVelocity = 8;
        SideSpeed = 300;
        SpeedReset.Enable();
    }
    public void Finish()
    {
        Debug.Log("finished level");
        SideSpeed = 0;
        ForwardVelocity = 0;
    }
    public void SpeedBoost()
    {
        Debug.Log("Speed Boost Activated");
        ForwardVelocity = 20;
        Invoke("ResetSpeed",2);
    }
    public void ResetSpeed()
    {
        ForwardVelocity = 8;
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
        SpeedReset = GameObject.FindGameObjectWithTag("Buff").GetComponent<Speedboostblock>();

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
        if (body.transform.position.y <= -2)
        {
            Death();

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
