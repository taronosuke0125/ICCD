using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Timetext : MonoBehaviour
{
    public static string starttime="00:00";//Timeset.csで入力された時間を格納
    public static string finishtime="00:00";//Timeset.csで入力された時間を格納
    // Start is called before the first frame update
    void Start()
    {
        regist_time();
    }
    //渡された時間を登録画面に表示する
    public static void regist_time()
    {
        GameObject.Find("StartTime").GetComponent<TextMeshProUGUI>().text = starttime;
        GameObject.Find("FinishTime").GetComponent<TextMeshProUGUI>().text = finishtime;
    }
}
