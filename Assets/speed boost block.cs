using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Speedboostblock : MonoBehaviour
{
    // Start is called before the first frame update
  
    Movement Speedy;
    void Start()
    {
        Speedy = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }
    void OnCollisionEnter(Collision Playi)
    {
        if (Playi.gameObject.name == "Player")
        {
            Speedy.SpeedBoost();
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
        gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
      
    }
}
