using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class setstartday : MonoBehaviour

{
    int flug=startday.changeflug;
    DateTime now=CreateDate.SelectDate;
    //DesignedCalender���Q�Ƃ���悤�ɕύX(1/25�X�V)
    DateTime Date= DesignedCalendar.selectedDate;
    public static DateTime starttime;
    public static DateTime finish;
    public static string planname="blank";
    // Start is called before the first frame update
    void Start()
    {
        //SetPlan�V�[����42���J�����_�[����̏������炤(flug==1,2,3�̎�)
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
            //�ҏW�O�̗\�������o�^
            Transform DAY = GameObject.Find("Start").transform.GetChild(1);
            Transform DAY2 = GameObject.Find("Finish").transform.GetChild(1);
            Data p1 = PlanList.DataList[Edit.changenumber];
            Debug.Log("changing date");
            p1.view();
            starttime = p1.Start;
            finish = p1.Finish;
            //�ҏW��ʂƂ��ė��p����Ƃ�
            Timetext.starttime = starttime.ToString("HH:mm");
            Timetext.finishtime = finish.ToString("HH:mm");
            DAY.GetComponent<Text>().text = starttime.ToString("yyyy/MM/dd");
            DAY2.GetComponent<Text>().text = finish.ToString("yyyy/MM/dd");
        }
        else if (flug == 4)
        {
            //WantSet�V�[���ŃJ�����_�[����̏����󂯎��
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
