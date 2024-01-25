using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpLetter : MonoBehaviour
  {
    public Movement GetLett;
    public  TextMeshProUGUI LetterUp;
    public UnityEngine.KeyCode letup1;
    // Start is called before the first frame update
    void Start()
    {
        LetterUp.SetText("x");
        // called from movement
        GetLett =GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
  

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeKey ()
    {
        // declare char variable and set to up key var from movement

        letup1 = GetLett.UpKey;

        //convert to string and set text to value
        string letup2 = letup1.ToString();
        LetterUp.SetText(letup2);
    }
}
