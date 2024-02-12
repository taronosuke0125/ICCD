using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class WantTimeText : MonoBehaviour
{
    public static int term = 1200;//Timeset.cs‚Å“ü—Í‚³‚ê‚½ŠÔ‚ğŠi”[
    public static string deadlinetime = "13:00";//Timeset.cs‚Å“ü—Í‚³‚ê‚½ŠÔ‚ğŠi”[
    public static int min = 1500;//Timeset.cs‚Å“ü—Í‚³‚ê‚½ŠÔ‚ğŠi”[
    public static int max = 1800;//Timeset.cs‚Å“ü—Í‚³‚ê‚½ŠÔ‚ğŠi”[

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "WantSet")
        {
            regist_time(0); regist_time(1); regist_time(2); regist_time(3);
        }
    }
    //“n‚³‚ê‚½ŠÔ‚ğ“o˜^‰æ–Ê‚É•\¦‚·‚é
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
   
    //4Œ…‚Ì®”‚ğHHH:mm‚ÌŒ`‚Ì•¶š—ñ‚É•ÏŠ·‚·‚é
    public static string IntToTimeSpanstr(int a)
    {
        string span;
        int hours = 0, minutes = 0;
        hours = a / 100;
        minutes = a % 100;
        //hours‚Ü‚½‚Íminutes‚ª1Œ…‚Ìê‡‚Í0‚ğæ“ª‚É•t‚¯‚é
        span = ((hours < 10) ? "0" + hours.ToString() : hours.ToString())+":"+((minutes < 10) ? "0"+minutes.ToString() : minutes.ToString());
        return span;
    }
    //4Œ…‚Ì®”‚ğTimeSpan‚É•ÏŠ·‚·‚é(a‚Í0‚©‚ç99959)
    public static TimeSpan IntToTimeSpan(int a)
    {
        int days = 0, hours = 0, minutes = 0;
        int time1 = a / 100;//a‚Ìã3Œ…
        int time2 = a % 100;//a‚Ì‰º3Œ…
        minutes = time2 % 60;
        time1 += time2 / 60;
        hours = time1 % 24;
        days = time1 / 24;
        return new TimeSpan(days, hours, minutes, 0);
    }
    //TimeSpan‚ğ4Œ…‚Ì®”‚É•ÏŠ·‚·‚é(‹t•ÏŠ·—p), span‚ÍMM:HHH:mm‚ÌŒ`®
   /* public static int TimeSpanToInt(TimeSpan span)
    {

    }*/
}
