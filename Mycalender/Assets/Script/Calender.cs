using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Calender : MonoBehaviour
{
    //日付取得用
    public static DateTime SelectDate;
    private DateTime D_Date;
    private int startday;
    private void CalenderController()
    {
        int days = 1;
        int overday = 1;
        //SelectDateの月の最初の日付
        D_Date = new DateTime(SelectDate.Year, SelectDate.Month, 1);
        int year = SelectDate.Year;//年
        int month = SelectDate.Month;//月
        int day = SelectDate.Day;//日
        //最初の日付のようにを取得
        DayOfWeek firstDate = D_Date.DayOfWeek;
        //何日まであるか
        int monthEnd = DateTime.DaysInMonth(year, month);
        //前月が何日まであるか
        SelectDate = SelectDate.AddMonths(-1);
        month = SelectDate.Month;
        SelectDate = SelectDate.AddMonths(1);
        int lastmonth = DateTime.DaysInMonth(year, month);
        switch (firstDate)
        {
            case DayOfWeek.Sunday:
                startday = 0;
                break;
            case DayOfWeek.Monday:
                startday = 1;
                break;
            case DayOfWeek.Tuesday:
                startday = 2;
                break;
            case DayOfWeek.Wednesday:
                startday = 3;
                break;
            case DayOfWeek.Thursday:
                startday = 4;
                break;
            case DayOfWeek.Friday:
                startday = 5;
                break;
            case DayOfWeek.Saturday:
                startday = 6;
                break;
        }
        int lastmonthdays = lastmonth - startday + 1;

        for(int i=0; i<42; i++)
        {
            if (i >= startday)
            {
                if (days <= monthEnd)
                {
                    //文字を入れる
                    Transform DAY = GameObject.Find("dates").transform.GetChild(i);
                    DateTime tmp = D_Date;//一次変数
                    DayOfWeek num = tmp.DayOfWeek;
                    //土曜日青・日曜日赤
                    switch (num)
                    {
                        case DayOfWeek.Sunday:
                            DAY.GetChild(0).GetComponent<Text>().color = Color.red;
                            break;
                        case DayOfWeek.Saturday:
                            DAY.GetChild(0).GetComponent<Text>().color = Color.blue;
                            break;
                        default:
                            DAY.GetChild(0).GetComponent<Text>().color = Color.black;
                            break;

                    }
                    DAY.GetChild(0).GetComponent<Text>().text = D_Date.Day.ToString();
                    D_Date = D_Date.AddDays(1);
                    days++;
                }
                else
                {
                    Transform DAY = GameObject.Find("dates").transform.GetChild(i);
                    DAY.GetChild(0).GetComponent<Text>().color = Color.gray;
                    DAY.GetChild(0).GetComponent<Text>().text = overday.ToString();
                    GameObject button = GameObject.Find("dates").transform.GetChild(i).gameObject;
                    button.GetComponent<Button>().onClick.RemoveAllListeners();
                    overday++;
                }
            }
            else
            {
                Transform DAY = GameObject.Find("dates").transform.GetChild(i);
                DAY.GetChild(0).GetComponent<Text>().color = Color.gray;
                DAY.GetChild(0).GetComponent<Text>().text = lastmonthdays.ToString();
                GameObject button = GameObject.Find("dates").transform.GetChild(i).gameObject;
                button.GetComponent<Button>().onClick.RemoveAllListeners();
                lastmonthdays++;
            }
        }
    }
    public GameObject canvas;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<42; i++)
        {
            GameObject button = Instantiate(prefab, canvas.transform);
            button.GetComponent<Button>();
        }
        SelectDate = DateTime.Now;
        CalenderController();
    }


}
