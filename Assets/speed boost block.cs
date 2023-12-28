using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Speedboostblock : MonoBehaviour
{
    // Start is called before the first frame update
    Object SpeedBoost;
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
