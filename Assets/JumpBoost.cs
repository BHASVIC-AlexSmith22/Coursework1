using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    Movement Jumpy;
    void Start()
    {
        Jumpy = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }
    void OnCollisionEnter(Collision Playi)
    {
        if (Playi.gameObject.name == "Player")
        {
            Jumpy.JumpBoost();
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
    // Update is called once per frame
}
