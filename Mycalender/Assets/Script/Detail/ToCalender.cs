using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToCalender : MonoBehaviour
{
    //detailシーンおよびWantViewシーンで使用
   public void ToCalenderScene()
    {
        SceneManager.LoadScene("Calender");
    }
}
