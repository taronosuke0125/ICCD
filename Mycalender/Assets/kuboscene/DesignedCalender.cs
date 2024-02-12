using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class DesignedCalendar : MonoBehaviour
{
    public GameObject canvas;  // エディタから指定
    public GameObject prefab;  // エディタから指定
    public Text displayText;   // 表示するテキストオブジェクト
    public Text monthYearText; // 追加: 年月を表示するテキストオブジェクト
    private DateTime SelectDate;
    private DateTime D_Date;
    private int startdate;
   // 追加: 保存するための変数(makecalender.csでいうChangeDate)
    public static DateTime selectedDate;

    void Start()
    {
        for (int i = 0; i < 42; i++)
        {
            GameObject button = Instantiate(prefab, canvas.transform);
            button.GetComponent<Button>();
        }

        // 追加: 年月を表示するテキストオブジェクトの初期設定
        // 注意: オブジェクトがアタッチされていることを確認する
        if (monthYearText == null)
        {
            Debug.LogError("monthYearText is not assigned.");
        }
        else
        {
            UpdateMonthYearText();
        }

        SelectDate = DateTime.Now;
        CalendarController();
        //キャンセル用のボタンクリックイベント
        Button cancelbutton = GameObject.Find("Button").GetComponent<Button>();
        cancelbutton.onClick.AddListener(()=> { set_Date(selectedDate, startday.changeflug); });
        // 追加: 翌月に移動するボタンのクリックイベント
        Button nextMonthButton = GameObject.Find("NextMonthButton").GetComponent<Button>();
        nextMonthButton.onClick.AddListener(MoveToNextMonth);

        // 追加: 前月に移動するボタンのクリックイベント
        Button prevMonthButton = GameObject.Find("PrevMonthButton").GetComponent<Button>();
        prevMonthButton.onClick.AddListener(MoveToPrevMonth);
    }

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
                startdate = 0;
                break;
            case DayOfWeek.Monday:
                startdate = 1;
                break;
            case DayOfWeek.Tuesday:
                startdate = 2;
                break;
            case DayOfWeek.Wednesday:
                startdate = 3;
                break;
            case DayOfWeek.Thursday:
                startdate = 4;
                break;
            case DayOfWeek.Friday:
                startdate = 5;
                break;
            case DayOfWeek.Saturday:
                startdate = 6;
                break;
        }
        int lastmonthdays = lastmonth - startdate + 1;

        for (int i = 0; i < 42; i++)
        {
            if (i >= startdate)
            {
                if (days <= monthEnd)
                {
                    // 文字を入れる
                    Transform DAY = canvas.transform.GetChild(i);
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
                    GameObject button = canvas.transform.GetChild(i).gameObject;
                    button.GetComponent<Button>().onClick.RemoveAllListeners();
                    //startday.changeflugによってボタンを押した時の遷移先が変わる
                    button.GetComponent<Button>().onClick.AddListener(() => { set_Date(tmp,startday.changeflug); });
                    D_Date = D_Date.AddDays(1);
                    days++;
                }
                else
                {
                    Transform DAY = canvas.transform.GetChild(i);
                    DAY.GetChild(0).GetComponent<Text>().color = Color.gray;
                    DAY.GetChild(0).GetComponent<Text>().text = overday.ToString();
                    GameObject button = canvas.transform.GetChild(i).gameObject;
                    button.GetComponent<Button>().onClick.RemoveAllListeners();
                    overday++;
                }
            }
            else
            {
                Transform DAY = canvas.transform.GetChild(i);
                DAY.GetChild(0).GetComponent<Text>().color = Color.gray;
                DAY.GetChild(0).GetComponent<Text>().text = lastmonthdays.ToString();
                GameObject button = canvas.transform.GetChild(i).gameObject;
                button.GetComponent<Button>().onClick.RemoveAllListeners();
                lastmonthdays++;
            }
        }

        // 年月を表示するテキストオブジェクトを更新
        UpdateMonthYearText();
    }

    // 年月を表示するテキストを更新するメソッド
    void UpdateMonthYearText()
    {
        if (monthYearText != null)
        {
            monthYearText.text = SelectDate.ToString("yyyy/MM");
        }
        else
        {
            Debug.LogError("monthYearText is not assigned.");
        }
    }

    // 日付を保存するためのメソッド(numberが1,2,3ならSetPlanに遷移,4,5ならWantSetに遷移)
    void set_Date(DateTime date, int number)
    {
        selectedDate = date;
        // テキストオブジェクトに日付を表示
        displayText.text = selectedDate.ToString();
        Debug.Log(number);        
        if (number < 4)
            SceneManager.LoadScene("SetPlan");
        else
            SceneManager.LoadScene("WantSet");

    }
    //キャンセル用のメソッド(オーバーライド)
    void set_Date(int number)
    {
        if (number < 4)
            SceneManager.LoadScene("SetPlan");
        else
            SceneManager.LoadScene("WantSet");

    }


    // 翌月に移動するメソッド
    void MoveToNextMonth()
    {
        SelectDate = SelectDate.AddMonths(1);
        CalendarController();
    }

    // 前月に移動するメソッド
    void MoveToPrevMonth()
    {
        SelectDate = SelectDate.AddMonths(-1);
        CalendarController();
    }
}
