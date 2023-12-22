using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class floor : MonoBehaviour
{
    // Start is called before the first frame update
    Movement CheckY;
    void Start()
    {
       CheckY = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        void OnCollisionexit(Collision Playex)
        {
            if (Playex.gameObject.name == "player") { }

        }
    }
}
