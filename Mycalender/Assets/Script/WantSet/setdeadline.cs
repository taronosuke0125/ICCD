using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//DeadLine�I�u�W�F�N�g�ɃA�^�b�`
public class setdeadline : MonoBehaviour
{
    int flug;
    DateTime now;
    //DesignedCalender���Q�Ƃ���悤�ɕύX(1/25�X�V)
    DateTime Date;
    public static DateTime deadline;
    public static string wantplanname;

    private void Start()
    {
        //�ϐ��̏�����
        flug = startday.changeflug;
        now = CreateDate.SelectDate;
        Date = DesignedCalendar.selectedDate;

        switch (flug) 
        {
            case 4: //��肽�����ƃ��X�g�o�^���ɓ��ɂ���\��������
                this.transform.GetChild(1).GetComponent<Text>().text = Date.ToString("yyyy/MM/dd");
                deadline = Date;
                break;
            case 5://��肽�����ƕҏW���ɓ��ɂ���\��������
                break;
            default:
                //�o�^�V�[���ɍŏ��ɑJ�ڂ����ۂɌĂяo�����
                this.transform.GetChild(1).GetComponent<Text>().text = now.ToString("yyyy/MM/dd");
                deadline = Date;
                break;
        }
        
    }
}
