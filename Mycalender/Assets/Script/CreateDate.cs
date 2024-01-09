using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class CreateDate : MonoBehaviour
{
    //日付取得用
    public static DateTime SelectDate;
    private DateTime D_Date;
    private int startday;
    public static DateTime ToDate;
    //指定した日から七日間を表示する関数
    private void CalenderController(DateTime headdate)
    {   D_Date = headdate;
        for (int i = 0; i < 7; i++)
        {
            if (i == 0)
            {
                Title.GetComponent<SetTitle>().TitleController(headdate);
            }
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
            GameObject button = GameObject.Find("Dates").transform.GetChild(i).GetChild(0).gameObject;
            DateTime d = D_Date;
            button.GetComponent<Button>().onClick.AddListener(() => { ToDetailScene(d); });
                    D_Date = D_Date.AddDays(1);
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
        //最初にsavedataを読み込みリストを作成する

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
    public void ToDetailScene(DateTime date)
    {
        ToDate = date;
        SceneManager.LoadScene("PlanDetail");
    }
}
