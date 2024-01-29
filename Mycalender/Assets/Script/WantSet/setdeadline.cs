using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//DeadLineオブジェクトにアタッチ
public class setdeadline : MonoBehaviour
{
    int flug;
    DateTime now;
    //DesignedCalenderを参照するように変更(1/25更新)
    DateTime Date;
    public static DateTime deadline;
    public static string wantplanname;

    private void Start()
    {
        //変数の初期化
        flug = startday.changeflug;
        now = CreateDate.SelectDate;
        Date = DesignedCalendar.selectedDate;

        switch (flug) 
        {
            case 4: //やりたいことリスト登録時に日にちを表示させる
                this.transform.GetChild(1).GetComponent<Text>().text = Date.ToString("yyyy/MM/dd");
                break;
            case 5://やりたいこと編集時
                WantData p1 = WantPlanList.WantDataList[Edit.changenumber];//変更するやりたいことのデータを取得
                //期限の日程のテキストを変更前の期限に変更
                this.transform.GetChild(1).GetComponent<Text>().text = p1.DeadLine.ToString("yyyy/MM/dd");
                //時間表示を変更前のものに変更、DeadLine以外はTimeSpan型
                WantTimeText.deadlinetime = p1.DeadLine.ToString("HH:mm");
                WantTimeText.term = p1.Termstr;
                WantTimeText.min = p1.minstr;
                WantTimeText.max = p1.maxstr;
                break;
            default:
                //登録シーンに最初に遷移した際に呼び出される
                this.transform.GetChild(1).GetComponent<Text>().text = now.ToString("yyyy/MM/dd");
                break;
        }
        deadline = Date;
        
    }
}
