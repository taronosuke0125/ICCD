using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CreateDate : MonoBehaviour
{
    //日付取得用
    public static DateTime SelectDate;
    private DateTime D_Date;
    private int startday;
    //指定した日から七日間を表示する関数
    private void CalenderController(DateTime headdate)
    {
        int days = 1;
        int overday = 1;
        int year = headdate.Year;//年
        int month = headdate.Month;//月
        int day = headdate.Day;//日
        //何日まであるか
        int monthEnd = DateTime.DaysInMonth(year, month);
        D_Date = headdate;
        for (int i = 0; i < 7; i++)
        {
            if (i == 0)
            {
                Title.GetComponent<SetTitle>().TitleController(headdate);
            }
            //今月の終わりまで
            if (days <= monthEnd)
                {
                    //文字を入れる
                    Transform DAY = GameObject.Find("Dates").transform.GetChild(i);
                    DateTime tmp = D_Date;//一次変数
                    DayOfWeek num = tmp.DayOfWeek;
                    //土曜日青・日曜日赤
                    switch (num)
                    {
                        case DayOfWeek.Sunday:
                            DAY.GetChild(0).GetChild(0).GetComponent<Text>().color = Color.red;
                            break;
                        case DayOfWeek.Saturday:
                            DAY.GetChild(0).GetChild(0).GetComponent<Text>().color = Color.blue;
                            break;
                        default:
                            DAY.GetChild(0).GetChild(0).GetComponent<Text>().color = Color.black;
                            break;

                    }
                    DAY.GetChild(0).GetChild(0).GetComponent<Text>().text = D_Date.ToString("MM/dd");
                    DAY.GetChild(0).GetChild(1).GetComponent<Text>().text = D_Date.ToString("(ddd)");
                    D_Date = D_Date.AddDays(1);
                    days++;
                }
            //来月への切り替わり
                else
                {
                    Transform DAY = GameObject.Find("Dates").transform.GetChild(i);
                    DAY.GetChild(0).GetChild(0).GetComponent<Text>().color = Color.gray;
                    DAY.GetChild(0).GetChild(0).GetComponent<Text>().text = overday.ToString("MM/dd");
                    DAY.GetChild(0).GetChild(1).GetComponent<Text>().text = overday.ToString("(ddd)");
                    GameObject button = GameObject.Find("Dates").transform.GetChild(i).GetChild(0).gameObject;
                    Debug.Log(button.name);
                    button.GetComponent<Button>().onClick.RemoveAllListeners();
                    overday++;
                }
            
        }
        Debug.Log("set Date");
    }
    //WeekChange.csで呼び出されカレンダーを来週に進める
    public void ToNextWeekCalender()
    {
        SelectDate = SelectDate.AddDays(7);
        CalenderController(SelectDate);    
    }
    
    //WeekChange.csで呼び出されカレンダーを先週に進める
    public void ToLastWeekCalender()
    {
        SelectDate = SelectDate.AddDays(-7);
        CalenderController(SelectDate);
    }

    public GameObject canvas;
    public GameObject prefab;
    public GameObject Title;
    RectTransform DatesPos;
    Vector2 DatesPosoff;
    // Start is called before the first frame update
    void Start()
    {

        //ボタン7個生成
        for (int i = 0; i < 7; i++)
        {
            GameObject button = Instantiate(prefab, canvas.transform);
            button.GetComponent<Button>();
        }
        //スクロール画面の初期値を記録
        DatesPos = this.GetComponent<RectTransform>();
        DatesPosoff = DatesPos.anchoredPosition;
        //最初は今日を基準に日付を作成
        SelectDate = DateTime.Now;
        Debug.Log(SelectDate);
        CalenderController(SelectDate);
    }

    void Update()
    {   //上にスクロールしたら日付を前に進める
        if (DatesPos.anchoredPosition.y> 250)
        {
            this.GetComponent<RectTransform>().anchoredPosition=DatesPosoff;
            SelectDate=SelectDate.AddDays(1);
            CalenderController(SelectDate);
        }
        //下にスクロールしたら日付を戻す
        if (DatesPos.anchoredPosition.y < -250)
        {
            this.GetComponent<RectTransform>().anchoredPosition = DatesPosoff;
            SelectDate = SelectDate.AddDays(-1);
            CalenderController(SelectDate);
        }
    }
}
