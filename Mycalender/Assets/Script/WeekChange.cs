using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class WeekChange : MonoBehaviour
{
    public GameObject Dates;
    //ボタン押したときに呼び出す用。日付を7日分前に進める
    public void ToNextWeek()
    {
        Dates.GetComponent<CreateDate>().ToNextWeekCalender();
    }
    //ボタン押した時呼び出す用。日付を7日分戻す
    public void ToLastWeek()
    {
        Dates.GetComponent<CreateDate>().ToLastWeekCalender();
    }
}
