using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class WantTimetext : MonoBehaviour
{
    public static string term = "12:00";//Timeset.csで入力された時間を格納
    public static string deadline = "13:00";//Timeset.csで入力された時間を格納
    public static string min = "15:00";//Timeset.csで入力された時間を格納
    public static string max = "18:00";//Timeset.csで入力された時間を格納

    // Start is called before the first frame update
    void Start()
    {
        regist_time(0); regist_time(1); regist_time(2); regist_time(3);
    }
    //渡された時間を登録画面に表示する
    public static void regist_time(int number)
    {
        if (number == 0)
            GameObject.Find("TermTime").GetComponent<TextMeshProUGUI>().text = term;
        if (number == 1)
            GameObject.Find("DLTime").GetComponent<TextMeshProUGUI>().text = deadline;
        if (number==2)
            GameObject.Find("MinTime").GetComponent<TextMeshProUGUI>().text = min;
        if (number==3)
            GameObject.Find("MaxTime").GetComponent<TextMeshProUGUI>().text = max;
    }
}
