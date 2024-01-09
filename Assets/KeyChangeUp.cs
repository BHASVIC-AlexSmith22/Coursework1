using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyChangeUp : MonoBehaviour
{
    Movement KeyChange;
    public GameObject[] gameObjectArray;
    void Start()
    {
        KeyChange = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("KeyUp");
    }
    void OnCollisionEnter(Collision Playi)
    {
        if (Playi.gameObject.name == "Player")
        {
            KeyChange.KeyChangeUp();
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
        foreach (GameObject KeyUp in gameObjectArray)
        {
            KeyUp.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
