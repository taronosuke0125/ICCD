using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Memoedit : MonoBehaviour
{

    
  public InputField inputField;
  public Text field;

  public string smemo;


    // Start is called before the first frame update
    void Start()
    {
        inputField = inputField.GetComponent<InputField> ();
        field = field.GetComponent<Text> ();
    }

    public void InputText(){
                //テキストにinputFieldの内容を反映
        field.text = inputField.text;
        smemo = field.text;
     }
        
    }
