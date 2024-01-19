using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody body;
    Speedboostblock SpeedReset;
    JumpBoost JumpReset;
    FogCube FogReset;
    KeyChangeUp KeyUpBlockReset;
    KeyChangeDown KeyDownBlockReset;
    KeyChangeLeft KeyLeftBlockReset;
    KeyChangeRight KeyRightBlockReset;
    public float countdownOne;
    public int SideSpeed = 300;
    public int ForwardVelocity = 8;
    public int JumpHeight = 200;
    public float DuckHeight = 0.5f;
    public int Switcheroo;
    public int ArrayPos = 0;
    public int ArrayStartPos = 0;
    public int LevelStartX = 0;
    //variables which control movement controls
    public UnityEngine.KeyCode UpKey = (KeyCode)'w';
    public UnityEngine.KeyCode DownKey = (KeyCode)'s' ;
    public UnityEngine.KeyCode LeftKey = (KeyCode)'a';
    public UnityEngine.KeyCode RightKey = (KeyCode)'d';
    //array which holds next letter for key change blocks
    KeyCode[] LetterValueArray = new KeyCode[] { KeyCode.R, KeyCode.P, KeyCode.X, KeyCode.F, KeyCode.G, KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R,KeyCode.T, KeyCode.Y };
    

    //Death and finish mechanics called from other scripts
    //called from Obstacles and this scripts update function:
    public void Death()
    {
        Debug.Log("Death called");
        transform.position = new Vector3(LevelStartX, 1, 0);
        body.velocity = Vector3.zero;
        DuckHeight = 0.5f;
        JumpHeight = 200;
        ForwardVelocity = 8;
        SideSpeed = 300;
        SpeedReset.Enable();
        JumpReset.Enable();
        FogReset.Enable();
        KeyUpBlockReset.Enable();
        KeyDownBlockReset.Enable();
        KeyLeftBlockReset.Enable();
        KeyRightBlockReset.Enable();
        RenderSettings.fog = false;
        UpKey = (KeyCode)'w';
         DownKey = (KeyCode)'s';
        LeftKey = (KeyCode)'a';
         RightKey = (KeyCode)'d';
        ArrayPos = ArrayStartPos;
       
    }
      //called from finish script:
    public void Finish()
    {
        Debug.Log("finished level");
        DuckHeight = 0.5f;
        JumpHeight = 200;
        ForwardVelocity = 8;
        SideSpeed = 300;
        UpKey = (KeyCode)'w';
        DownKey = (KeyCode)'s';
        LeftKey = (KeyCode)'a';
        RightKey = (KeyCode)'d';
        ArrayStartPos = ArrayPos;
        LevelStartX = LevelStartX + 60;
        transform.position = new Vector3(LevelStartX, 1, 0);
    }
    //effects called from other scripts
     //called from SpeedBoostBlock:
    public void SpeedBoost()
    {
        Debug.Log("Speed Boost Activated");
        ForwardVelocity = 20;
        Invoke("ResetSpeed",2);
    }
        //called from JumpBoost:
    public void JumpBoost()
    {
        Debug.Log(" Jump Boost Activated");
        JumpHeight = 400;
        Invoke("ResetJump", 2);
    }
     //called from fog cube:
    public void FogCube() 
    {
        Debug.Log(" Fog Activated");
        RenderSettings.fog = true;
        Invoke("ResetFog", 3.5f);
    }
    //called from keychange up
    public void KeyChangeUp()
    {
        Debug.Log("Key change up");
        UpKey = LetterValueArray[ArrayPos];
        ArrayPos = ArrayPos + 1;

    }
    public void KeyChangeDown()
    {
        Debug.Log("Key change down");
        DownKey = LetterValueArray[ArrayPos];
        ArrayPos = ArrayPos + 1;

    }
    public void KeyChangeLeft()
    {
        Debug.Log("Key change Left");
        LeftKey = LetterValueArray[ArrayPos];
        ArrayPos = ArrayPos + 1;

    }
    public void KeyChangeRight()
    {
        Debug.Log("Key change right");
        RightKey = LetterValueArray[ArrayPos];
        ArrayPos = ArrayPos + 1;

    }
    //reset effects which are invoked in above scripts
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
        SpeedReset = GameObject.FindGameObjectWithTag("SpeedBoostTemp").GetComponent<Speedboostblock>();
        JumpReset = GameObject.FindGameObjectWithTag("JumpBoostTemp").GetComponent<JumpBoost>();
        FogReset = GameObject.FindGameObjectWithTag("FogCubeTemp").GetComponent<FogCube>();
        KeyUpBlockReset = GameObject.FindGameObjectWithTag("KeyUpTemp").GetComponent<KeyChangeUp>();
        KeyDownBlockReset = GameObject.FindGameObjectWithTag("KeyDownTemp").GetComponent<KeyChangeDown>();
        KeyLeftBlockReset = GameObject.FindGameObjectWithTag("KeyLeftTemp").GetComponent<KeyChangeLeft>();
        KeyRightBlockReset = GameObject.FindGameObjectWithTag("KeyRightTemp").GetComponent<KeyChangeRight>();

        //initiating values for letter array

    }

    // Update is called once per frame
    void Update()
    {
        //basic movement and controls
        // Right movement
        if (Input.GetKey(RightKey))
        {
            body.AddForce(new Vector3(SideSpeed * Time.deltaTime, 0, 0));
        }
        // Left movement
        if (Input.GetKey(LeftKey))
        {
            body.AddForce(new Vector3(-SideSpeed * Time.deltaTime, 0, 0));
        }
        // jump movement
        if (Input.GetKey(UpKey) & countdownOne ==0 & body.transform.position.y >= 1 & body.transform.position.y <= 1.01f)
        {
            Jump();
           
        }
    
        //Duck movement 
        if (Input.GetKey(DownKey) & countdownOne == 0) {
           transform.localScale = transform.localScale * DuckHeight;
            countdownOne = 1;
            Invoke("UnDuck", 0.5f);
            Invoke("WaitOneSec",1);
         
        }
        //kills player when they fall off side of map
        if (body.transform.position.y <= -3)
        {
            Death();

        }
        //Constant foward movement
        transform.position += transform.forward * (ForwardVelocity * Time.deltaTime);
    }

}
