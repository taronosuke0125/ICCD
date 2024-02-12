using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class WantTimeText : MonoBehaviour
{
    public static int term = 1200;//Timeset.csで入力された時間を格納
    public static string deadlinetime = "13:00";//Timeset.csで入力された時間を格納
    public static int min = 1500;//Timeset.csで入力された時間を格納
    public static int max = 1800;//Timeset.csで入力された時間を格納

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "WantSet")
        {
            regist_time(0); regist_time(1); regist_time(2); regist_time(3);
        }
    }
    //渡された時間を登録画面に表示する
    public void regist_time(int number)
    {
        if (number == 0)
            GameObject.Find("TermTime").GetComponent<TextMeshProUGUI>().text = IntToTimeSpanstr(term);
        if (number == 1)
            GameObject.Find("DLTime").GetComponent<TextMeshProUGUI>().text = deadlinetime;
        if (number==2)
            GameObject.Find("MinTime").GetComponent<TextMeshProUGUI>().text = IntToTimeSpanstr(min);
        if (number==3)
            GameObject.Find("MaxTime").GetComponent<TextMeshProUGUI>().text = IntToTimeSpanstr(max);
    }
   
    //4桁の整数をHHH:mmの形の文字列に変換する
    public static string IntToTimeSpanstr(int a)
    {
        string span;
        int hours = 0, minutes = 0;
        hours = a / 100;
        minutes = a % 100;
        //hoursまたはminutesが1桁の場合は0を先頭に付ける
        span = ((hours < 10) ? "0" + hours.ToString() : hours.ToString())+":"+((minutes < 10) ? "0"+minutes.ToString() : minutes.ToString());
        return span;
    }
    //4桁の整数をTimeSpanに変換する(aは0から99959)
    public static TimeSpan IntToTimeSpan(int a)
    {
        int days = 0, hours = 0, minutes = 0;
        int time1 = a / 100;//aの上3桁
        int time2 = a % 100;//aの下3桁
        minutes = time2 % 60;
        time1 += time2 / 60;
        hours = time1 % 24;
        days = time1 / 24;
        return new TimeSpan(days, hours, minutes, 0);
    }
    //TimeSpanを4桁の整数に変換する(逆変換用), spanはMM:HHH:mmの形式
   /* public static int TimeSpanToInt(TimeSpan span)
    {

    }*/
}
