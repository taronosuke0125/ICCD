using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class makecalender : MonoBehaviour
{

 public static DateTime SelectDate;
 private DateTime D_Date;
 private int startday;
 public static DateTime ChangeDate;

 private void CalendarController()
    {
        int days = 1;
        int overday = 1;

        D_Date = new DateTime(SelectDate.Year, SelectDate.Month, 1);  //SelectDateの月の最初の日付
        int year = SelectDate.Year; //年
        int month = SelectDate.Month; //月
        int day = SelectDate.Day; //日
        //最初の日付の曜日を取得
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
        for (int i = 0; i < 42; i++)
        {
            if (i >= startday)
            {
                if (days <= monthEnd)
                {
                    //文字を入れる
                    Transform DAY = GameObject.Find("buttons").transform.GetChild(i);
                    DateTime tmp = D_Date;//一時変数
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
                    //以下3行追加
                    GameObject button = GameObject.Find("buttons").transform.GetChild(i).gameObject;
                    button.GetComponent<Button>().onClick.RemoveAllListeners();
                    button.GetComponent<Button>().onClick.AddListener(() => { set_Date(tmp); });
                    D_Date = D_Date.AddDays(1);
                    days++;
                }
                else
                {
                    Transform DAY = GameObject.Find("buttons").transform.GetChild(i);
                    DAY.GetChild(0).GetComponent<Text>().color = Color.gray;
                    DAY.GetChild(0).GetComponent<Text>().text = overday.ToString();
                    GameObject button = GameObject.Find("buttons").transform.GetChild(i).gameObject;
                    button.GetComponent<Button>().onClick.RemoveAllListeners();
                    overday++;
                }
            }
            else
            {
                Transform DAY = GameObject.Find("buttons").transform.GetChild(i);
                DAY.GetChild(0).GetComponent<Text>().color = Color.gray;
                DAY.GetChild(0).GetComponent<Text>().text = lastmonthdays.ToString();
                GameObject button = GameObject.Find("buttons").transform.GetChild(i).gameObject;
                button.GetComponent<Button>().onClick.RemoveAllListeners();
                lastmonthdays++;
            }
        }
    }

 void set_Date(DateTime date)
    {
        Debug.Log(date);
        ChangeDate = date;
        
        SceneManager.LoadScene("SetPlan");
        //値を保存する処理など
    }
 
 public GameObject canvas;//エディタから指定
 public GameObject prefab;//エディタから指定

 void Start()
    {
        for (int i = 0; i < 42; i++)
        {
            GameObject button = Instantiate(prefab, canvas.transform);
            button.GetComponent<Button>();
        }
        SelectDate = DateTime.Now;
        CalendarController();
    }
}