using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class WeekChange : MonoBehaviour
{
    public GameObject Dates;
    //�{�^���������Ƃ��ɌĂяo���p�B���t��7�����O�ɐi�߂�
    public void ToNextWeek()
    {
        Dates.GetComponent<CreateDate>().ToNextWeekCalender();
    }
    //�{�^�����������Ăяo���p�B���t��7�����߂�
    public void ToLastWeek()
    {
        Dates.GetComponent<CreateDate>().ToLastWeekCalender();
    }
}
