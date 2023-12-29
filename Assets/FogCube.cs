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
    private void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
