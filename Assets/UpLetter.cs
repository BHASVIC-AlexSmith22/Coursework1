using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpLetter : MonoBehaviour
  {
    Movement GetLett;
    public TextMeshProUGUI LetterUp;
   
   
    // Start is called before the first frame update
    void Start()
    {
        LetterUp.SetText("W");
        GetLett = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ChangeKey ()
    {
        LetterUp = GetLett.KeyChangeUp;
    }
}
