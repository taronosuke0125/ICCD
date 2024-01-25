using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Dayap : MonoBehaviour
{
    // Start is called before the first frame update

     public Text Daytext;
    void Start()
    {
        Daytext.text = CreateDate.ToDate.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
