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
            //ボタンにその日付を保存
            button.transform.parent.GetComponent<ButtonDate>().day = D_Date;
            DateTime d = D_Date;
            button.GetComponent<Button>().onClick.AddListener(() => { ToDetailScene(d); });
            D_Date = D_Date.AddDays(1);
        }
        SetPlanName();
    }
    //リストに保持されている予定を該当する日付に表示する.
    public void SetPlanName()
    {
        int i;
        Debug.Log("datacount:" + PlanList.datacount);
        //7日間の予定初期化(プレハブ削除)
        for(i=0; i<7; i++)
        {
            GameObject parent = this.transform.GetChild(i).GetChild(0).GetChild(2).gameObject;
            foreach (Transform child in parent.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        for (i=0; i<PlanList.datacount; i++)
        {
            Debug.Log(i);
            Debug.Log("Sel:"+SelectDate);
            Debug.Log("S:" + PlanList.DataList[i].Start);
            Debug.Log("F:" + PlanList.DataList[i].Finish);
            if (PlanList.DataList[i].Finish < SelectDate.Date || SelectDate.AddDays(6).Date < PlanList.DataList[i].Start)
            {//予定が表示されている7日間の間にない時
                Debug.Log("Case1");
                continue;
            }else if (PlanList.DataList[i].Start < SelectDate.Date)
            {//予定開始日が先頭の日付よりも前
                if(PlanList.DataList[i].Finish <= SelectDate.AddDays(6).Date)
                {//予定終了日が最後尾の日付以前
                    Debug.Log("Case2");
                    int j = 0;
                    do
                    {
                        GameObject planview = this.transform.GetChild(j).GetChild(0).GetChild(2).gameObject;
                        GameObject planname = Instantiate(plantext, planview.transform);
                        planname.GetComponent<Text>().text = PlanList.DataList[i].Name;
                        j++;
                    } while ( SelectDate.Date.AddDays(j) <= PlanList.DataList[i].Finish);
                }
                else
                {//予定終了日が最後尾より後
                    Debug.Log("Case4");
                    int j ;
                    for(j=0 ; j < 7 ; j++)
                    {
                        GameObject planview = this.transform.GetChild(j).GetChild(0).GetChild(2).gameObject;
                        GameObject planname = Instantiate(plantext, planview.transform);
                        planname.GetComponent<Text>().text = PlanList.DataList[i].Name;
                    }
                }
            }
            else
            {//予定開始日が先頭の日付以降
                if (PlanList.DataList[i].Finish <= SelectDate.AddDays(6).Date)
                {//予定終了日が最後尾の日付以前
                    Debug.Log("Case5");
                    int j = 0;
                    //予定開始日が先頭の日付から何番目か
                    while(SelectDate.Date.AddDays(j) != PlanList.DataList[i].Start)
                    {
                        j++;
                    }

                    do
                    {
                        GameObject planview = this.transform.GetChild(j).GetChild(0).GetChild(2).gameObject;
                        GameObject planname = Instantiate(plantext, planview.transform);
                        planname.GetComponent<Text>().text = PlanList.DataList[i].Name;
                        j++;
                    } while (SelectDate.Date.AddDays(j) <= PlanList.DataList[i].Finish);
                }
                else
                {//予定終了日が最後尾より後
                    Debug.Log("Case3");
                    int j = 0;
                    //予定開始日が先頭の日付から何番目か
                    while (SelectDate.Date.AddDays(j) != PlanList.DataList[i].Start)
                    {
                        j++;
                    }

                    do
                    {
                        GameObject planview = this.transform.GetChild(j).GetChild(0).GetChild(2).gameObject;
                        GameObject planname = Instantiate(plantext, planview.transform);
                        planname.GetComponent<Text>().text = PlanList.DataList[i].Name;
                        j++;
                    } while (j<7);
                }
            }
        }
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
    public GameObject plantext;
    public GameObject canvas;
    public GameObject prefab;
    public GameObject Title;
    RectTransform DatesPos;
    Vector2 DatesPosoff;
    // Start is called before the first frame update
    //予定データが呼び出された後に実行される必要がある
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
    //予定詳細シーンへ遷移
    public void ToDetailScene(DateTime date)
    {
        ToDate = date;
        SceneManager.LoadScene("PlanDetail");
    }
}
