using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Enable() 
    {
        for (int KidCount = 0; KidCount < transform.childCount; KidCount++)
        {
            transform.GetChild(KidCount).gameObject.SetActive(true);
        }
    }
}
