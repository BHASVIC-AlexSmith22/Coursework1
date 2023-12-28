using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishlevel : MonoBehaviour
{
    // Start is called before the first frame update
    Movement finish;
    void Start()
    {
        finish = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }
    void OnCollisionEnter(Collision Playe)
    {
        if (Playe.gameObject.name == "Player")
        {
            finish.Finish();
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}


