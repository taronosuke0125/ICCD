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
                deadline = Date;
                break;
            case 5://やりたいこと編集時に日にちを表示させる
                break;
            default:
                //登録シーンに最初に遷移した際に呼び出される
                this.transform.GetChild(1).GetComponent<Text>().text = now.ToString("yyyy/MM/dd");
                deadline = Date;
                break;
        }
        
    }
}
