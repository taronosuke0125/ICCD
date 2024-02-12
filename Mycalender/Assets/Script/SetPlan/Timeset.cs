using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using System;
using TMPro;
public class Timeset : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI time1;
    [SerializeField]
    private TextMeshProUGUI time2;
    [SerializeField]
    private GameObject Panel;
    [SerializeField]
    private GameObject ErrorText;
    private static int flag;//0ならstarttimeに記録、1ならfinishtimeに記録、2ならterm、3ならmin、4ならmax(1/24更新)
    public static int count=0;
    //ボタンを押すとそのボタンに登録された数字を追加してtimeに出力
    public void Push_Button(int number)
    {
        if (count < 2)
        {
            time1.text += number;
            count++;
        }else if(count<4)
        {
            time2.text += number;
            count++;
        }
        Debug.Log("count:" + count);

    }
    //ボタンを押すと末尾1文字削除
    public void Delete_Button()
    {
        if (count > 2)
        {   
            int num=time2.text.Length-1;
            time2.text=time2.text.Remove(num,1);
            count--;
        }
        else if(count>0)
        {
            int num = time1.text.Length - 1;
            time1.text=time1.text.Remove(num, 1);
            count--;
        }
    }
    //ボタンを押すと現在時刻を入力する
    public void Now_Button()
    {
        string hour = DateTime.Now.ToString("HH");
        string minutes= DateTime.Now.ToString("mm");
        time1.text = hour;
        time2.text = minutes;
        count = 4;
    }
    //ボタンを押すと入力を全削除する
    public void Clear_Button()
    {
        time1.text = "";
        time2.text = "";
        count = 0;
    }
    //ボタンを押すとボタンパネルを非表示にする
    public void Return_Button()
    {
        Clear_Button();
        this.gameObject.transform.parent.parent.parent.gameObject.SetActive(false);
    }
    //ボタンを押すと表示されている時間を格納する
    public void Enter_Button()
    {
        if(count != 4)
        {//時間を4桁入力していないときはエラー文を3秒間表示しEnterを取り消す。
            ErrorText.GetComponent<TextMeshProUGUI>().text = "#入力が不十分です";
            StartCoroutine(ShowSecond(ErrorText, 3f));
            return;
        }

        //TimeSpanに入れる時間を整数に変換
        int time = int.Parse(time1.text) * 100 + int.Parse(time2.text);
        switch (flag)
        {
            //0ならstarttimeに記録、1ならfinishtime、2ならterm、3ならdeadline、4ならmin、5ならmaxに記録(2/12更新)
            case 0:
                if (OverFlowChecker(0))
                {
                    ErrorDateTime();
                    return;
                }
                Timetext.starttime = time1.text + ":" + time2.text;
                Timetext.regist_time();
                break;
            case 1:
                if (OverFlowChecker(0))
                {
                    ErrorDateTime();
                    return;
                }
                Timetext.finishtime = time1.text + ":" + time2.text;
                Timetext.regist_time();
                break;
            case 2:
                if (OverFlowChecker(1))
                {
                    ErrorDateTime();
                    return;
                }
                WantTimeText.term = time;
                GameObject.Find("RegistManager").GetComponent<WantTimeText>().regist_time(0);
                break;
            case 3:
                if (OverFlowChecker(0))
                {
                    ErrorDateTime();
                    return;
                }
                WantTimeText.deadlinetime = time1.text + ":" + time2.text;
                GameObject.Find("RegistManager").GetComponent<WantTimeText>().regist_time(1);
                break;
            case 4:
                if (OverFlowChecker(1))
                {
                    ErrorDateTime();
                    return;
                }
                WantTimeText.min = time;
                GameObject.Find("RegistManager").GetComponent<WantTimeText>().regist_time(2);
                break;
            case 5:
                if (OverFlowChecker(1))
                {
                    ErrorDateTime();
                    return;
                }
                WantTimeText.max = time;
                GameObject.Find("RegistManager").GetComponent<WantTimeText>().regist_time(3);
                break;
        }
        Return_Button();
        Debug.Log("Excuted");
    }
    //ボタンを押すとボタンパネルを表示する    
    public void Active_Button(int i)
    {
        flag = i;
        Panel.SetActive(true);
    }
    //DateTimeでは24:00以上,TimeSpanでは999:59より大きい入力が与えられているか確認するメソッド(i=0でDateTime,i=1でTimeSpan)
    public bool OverFlowChecker(int i)
    {
        int hours = int.Parse(time1.text);
        int minutes = int.Parse(time2.text);
        if (i == 0)
        {
            if (hours > 23 || minutes > 59)
            {
                return true;
            }
        }
        else
        {
            if (minutes > 59)
            {
                return true;
            }
        }
        
        return false;
    }
    //DateTimeの不正に関してエラー表示を行うメソッド
    public void ErrorDateTime()
    {
        ErrorText.GetComponent<TextMeshProUGUI>().text= "#適切な時間を入力してください";
        StartCoroutine(ShowSecond(ErrorText, 3f));
    }
    // 引数で与えられたオブジェクトを表示し、引数の秒数後に非表示にするコルーチン
    IEnumerator ShowSecond(GameObject targetObj, float sec)
    {
        targetObj.SetActive(true); //引数で指定されたオブジェクトを表示する
        yield return new WaitForSeconds(sec); // 引数で指定された秒数待つ
        targetObj.SetActive(false); //引数で指定されたオブジェクトを非表示にする
    }
}
