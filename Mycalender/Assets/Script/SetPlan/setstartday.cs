using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class setstartday : MonoBehaviour

{
    int flug=startday.changeflug;
    DateTime now=CreateDate.SelectDate;
    //DesignedCalenderを参照するように変更(1/25更新)
    DateTime Date= DesignedCalendar.selectedDate;
    public static DateTime starttime;
    public static DateTime finish;
    public static string planname="blank";
    // Start is called before the first frame update
    void Start()
    {
        //SetPlanシーンで42日カレンダーからの情報をもらう(flug==1,2,3の時)
        if (flug ==1)
        {
            Transform DAY = GameObject.Find("Start").transform.GetChild(1);
            Transform DAY2 = GameObject.Find("Finish").transform.GetChild(1);
            Debug.Log(finish);
             DAY.GetComponent<Text>().text = Date.ToString("yyyy/MM/dd");
             starttime =Date;
             DAY2.GetComponent<Text>().text = finish.ToString("yyyy/MM/dd");
        }
        else if (flug ==2)
        {
            Transform DAY = GameObject.Find("Start").transform.GetChild(1);
            Transform DAY2 = GameObject.Find("Finish").transform.GetChild(1);
             DAY.GetComponent<Text>().text = starttime.ToString("yyyy/MM/dd");
             DAY2.GetComponent<Text>().text = Date.ToString("yyyy/MM/dd");
             finish =Date;
        }
        else if(flug == 3)
        {
            //編集前の予定日程を登録
            Transform DAY = GameObject.Find("Start").transform.GetChild(1);
            Transform DAY2 = GameObject.Find("Finish").transform.GetChild(1);
            Data p1 = PlanList.DataList[Edit.changenumber];
            Debug.Log("changing date");
            p1.view();
            starttime = p1.Start;
            finish = p1.Finish;
            //編集画面として利用するとき
            Timetext.starttime = starttime.ToString("HH:mm");
            Timetext.finishtime = finish.ToString("HH:mm");
            DAY.GetComponent<Text>().text = starttime.ToString("yyyy/MM/dd");
            DAY2.GetComponent<Text>().text = finish.ToString("yyyy/MM/dd");
        }
        else if (flug == 4)
        {
            //WantSetシーンでカレンダーからの情報を受け取る
            Transform DAY = GameObject.Find("Start").transform.GetChild(1);
            Transform DAY2 = GameObject.Find("Finish").transform.GetChild(1);
            Debug.Log(flug);
            DAY.GetComponent<Text>().text = now.ToString("yyyy/MM/dd");
            starttime = now;
        }
        else
        {
            Transform DAY = GameObject.Find("Start").transform.GetChild(1);
            Transform DAY2 = GameObject.Find("Finish").transform.GetChild(1);
             Debug.Log(flug);
             DAY.GetComponent<Text>().text = now.ToString("yyyy/MM/dd");
             starttime =now;
             DAY2.GetComponent<Text>().text = now.ToString("yyyy/MM/dd");
             finish =now;
        }
    }
}
