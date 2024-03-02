using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    // Start is called before the first frame update
    Movement kill;
    void Start()
    {
        kill = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }
    void OnCollisionEnter(Collision Play)
    {
        if(Play.gameObject.name == "Player") {
           kill.Death(); 
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
