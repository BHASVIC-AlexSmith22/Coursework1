using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DownLetter : MonoBehaviour
{
    public Movement GetLett;
    public UnityEngine.KeyCode letup1;
    private TMP_Text LetterUp;
    // Start is called before the first frame update
    void Start()
    {
        //set textmesh pro reference
        LetterUp = GetComponent<TMP_Text>();
        LetterUp.text = ("s");
        // called from movement
        GetLett = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeKey()
    {
        // declare char variable and set to up key var from movement

        letup1 = GetLett.DownKey;

        //convert to string and set text to value
        string letup2 = letup1.ToString();
        LetterUp.SetText(letup2);
    }
}
