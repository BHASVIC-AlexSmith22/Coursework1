using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody body;
    Speedboostblock SpeedReset;
    JumpBoost JumpReset;
    FogCube FogReset;
    public float countdownOne;
    public int SideSpeed = 300;
    public int ForwardVelocity = 8;
    public int JumpHeight = 200;
    public float DuckHeight = 0.5f;
    public int Switcheroo;
    //Death and finish mechanics called from other scripts
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
        JumpReset.Enable();
        FogReset.Enable();
        RenderSettings.fog = false;
    }
    public void Finish()
    {
        Debug.Log("finished level");
        SideSpeed = 0;
        ForwardVelocity = 0;
    }
    //effects called from other scripts
    public void SpeedBoost()
    {
        Debug.Log("Speed Boost Activated");
        ForwardVelocity = 20;
        Invoke("ResetSpeed",2);
    }
    public void JumpBoost()
    {
        Debug.Log(" Jump Boost Activated");
        JumpHeight = 400;
        Invoke("ResetJump", 2);
    }
    public void FogCube() 
    {
        Debug.Log(" Fog Activated");
        RenderSettings.fog = true;
        Invoke("ResetFog", 3.5f);
    }
    //reset effects which are invoked above
    public void ResetSpeed()
    {
        ForwardVelocity = 8;
    }
    public void ResetJump()
    {
        JumpHeight = 200;
    }
    public void ResetFog() 
    {
        RenderSettings.fog = false;
    }
    //jump method
    public void Jump()
    {
        body.AddForce(new Vector3(0, JumpHeight, 0));
        countdownOne = 1;
        Invoke("WaitOneSec", 1);
    }
    //timer method for jump and duck
    public void WaitOneSec() {
        countdownOne = 0;
        
    }
    // unduck method called after timer
    public void UnDuck() {
        transform.localScale = transform.localScale * 2f;
    }
    // Start is called before the first frame update
    void Start()
    {
        //linking other scripts to fields
        SpeedReset = GameObject.FindGameObjectWithTag("SpeedBoost").GetComponent<Speedboostblock>();
        JumpReset = GameObject.FindGameObjectWithTag("JumpBoost").GetComponent<JumpBoost>();
        FogReset = GameObject.FindGameObjectWithTag("FogCube").GetComponent<FogCube>();
    }

    // Update is called once per frame
    void Update()
    {
        //basic movement and controls
        if (Input.GetKey("d"))
        {
            body.AddForce(new Vector3(SideSpeed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey("a"))
        {
            body.AddForce(new Vector3(-SideSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey("w") & countdownOne ==0 & body.transform.position.y >= 1 & body.transform.position.y <= 1.01f)
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
