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
                break;
            case 5://��肽�����ƕҏW��
                WantData p1 = WantPlanList.WantDataList[Edit.changenumber];//�ύX�����肽�����Ƃ̃f�[�^���擾
                //�����̓����̃e�L�X�g��ύX�O�̊����ɕύX
                this.transform.GetChild(1).GetComponent<Text>().text = p1.DeadLine.ToString("yyyy/MM/dd");
                //���ԕ\����ύX�O�̂��̂ɕύX�ADeadLine�ȊO��TimeSpan�^
                WantTimeText.deadlinetime = p1.DeadLine.ToString("HH:mm");
                WantTimeText.term = p1.Termstr;
                WantTimeText.min = p1.minstr;
                WantTimeText.max = p1.maxstr;
                break;
            default:
                //�o�^�V�[���ɍŏ��ɑJ�ڂ����ۂɌĂяo�����
                this.transform.GetChild(1).GetComponent<Text>().text = now.ToString("yyyy/MM/dd");
                break;
        }
        deadline = Date;
        
    }
}
