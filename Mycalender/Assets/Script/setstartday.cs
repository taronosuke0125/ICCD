using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class setstartday : MonoBehaviour

{
    int flug=startday.changeflug;
    DateTime now=CreateDate.SelectDate;
    DateTime Date= makecalender.ChangeDate;
    public static DateTime starttime;
    public static DateTime finish;
    public static string planname="blank";
    // Start is called before the first frame update
    void Start()
    {
        Transform DAY = GameObject.Find("Start").transform.GetChild(1);
        Transform DAY2 = GameObject.Find("Finish").transform.GetChild(1);
        if (flug ==1)
        {
             Debug.Log(finish);
             DAY.GetComponent<Text>().text = Date.ToString("yyyy/MM/dd");
             starttime =Date;
             DAY2.GetComponent<Text>().text = finish.ToString("yyyy/MM/dd");
        }
        else if (flug ==2)
        {
             DAY.GetComponent<Text>().text = starttime.ToString("yyyy/MM/dd");
             DAY2.GetComponent<Text>().text = Date.ToString("yyyy/MM/dd");
             finish =Date;
        }
        else if(flug == 3)
        {
            //•ÒW‘O‚Ì—\’è“ú’ö‚ğ“o˜^
            Data p1 = PlanList.DataList[Edit.changenumber];
            Debug.Log("changing date");
            p1.view();
            starttime = p1.Start;
            finish = p1.Finish;
            //•ÒW‰æ–Ê‚Æ‚µ‚Ä—˜—p‚·‚é‚Æ‚«
            DAY.GetComponent<Text>().text = starttime.ToString("yyyy/MM/dd");
            DAY2.GetComponent<Text>().text = finish.ToString("yyyy/MM/dd");
            Timetext.starttime=starttime.ToString("HH:mm");
            Timetext.finishtime = finish.ToString("HH:mm");
        }
        else if(flug == 4)
        {
            //
        }
        else 
        {
             Debug.Log(flug);
             DAY.GetComponent<Text>().text = now.ToString("yyyy/MM/dd");
             starttime =now;
             DAY2.GetComponent<Text>().text = now.ToString("yyyy/MM/dd");
             finish =now;
        }
    }
}
