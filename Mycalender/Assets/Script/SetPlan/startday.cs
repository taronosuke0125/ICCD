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
        //�\��J�n����I��
        changeflug = 1;
        SceneManager.LoadScene("New Scene");
    }
     public void OnClickfinishButton()
    {
        //�\��I������I��
        changeflug = 2;
        SceneManager.LoadScene("New Scene");

    }
    public void OnClickDLButton()
    {
        //��肽�����Ƃ̊�����I��
        changeflug = 4;
        SceneManager.LoadScene("New Scene");

    }
      
}
