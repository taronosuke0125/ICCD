using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class startday : MonoBehaviour
{
    public static DateTime SelectDate;
    public static int changeflug;
    public void OnClickStartButton()
    {
        changeflug = 1;
        SceneManager.LoadScene("New Scene");
    }
     public void OnClickfinishButton()
    {
        changeflug = 2;
        SceneManager.LoadScene("New Scene");

    }
      
}
