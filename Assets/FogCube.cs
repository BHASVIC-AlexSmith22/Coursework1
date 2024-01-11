using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogCube : MonoBehaviour
{
    Movement Foggy;
    void Start()
    {
        Foggy = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }
    void OnCollisionEnter(Collision Playo)
    {
        if (Playo.gameObject.name == "Player")
        {
            Foggy.FogCube();
            Disable();
        }

    }
    //removes block when players hits it
    private void Disable()
    {
        gameObject.SetActive(false);
    }
    // resets block on player death
    //Called from movement:
    public void Enable()
    {
        for (int KidCount = 0; KidCount < transform.childCount; KidCount++)
        {
            transform.GetChild(KidCount).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
