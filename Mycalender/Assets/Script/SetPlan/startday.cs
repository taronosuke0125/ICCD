using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class startday : MonoBehaviour
{
    public static int changeflug;
    public void OnClickStartButton()
    {
        //予定開始日を選択
        changeflug = 1;
        SceneManager.LoadScene("New Scene");
    }
     public void OnClickfinishButton()
    {
        //予定終了日を選択
        changeflug = 2;
        SceneManager.LoadScene("New Scene");

    }
    public void OnClickDLButton()
    {
        //やりたいことの期限を選択
        changeflug = 4;
        SceneManager.LoadScene("New Scene");

    }
      
}
