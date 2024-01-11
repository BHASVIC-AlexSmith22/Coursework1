using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyChangeDown : MonoBehaviour
{
    Movement KeyChange;
    void Start()
    {
        KeyChange = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }
    void OnCollisionEnter(Collision Playi)
    {
        if (Playi.gameObject.name == "Player")
        {
            KeyChange.KeyChangeDown();
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
