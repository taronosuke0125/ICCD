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
        switch (flag)
        {
            //0ならstarttimeに記録、1ならfinishtimeに記録、2ならterm、3ならmin、4ならmax(1/24更新)
            case 0:
                Timetext.starttime = time1.text + ":" + time2.text;
                Timetext.regist_time();
                break;
            case 1:
                Timetext.finishtime = time1.text + ":" + time2.text;
                Timetext.regist_time();
                break;
            case 2:
                WantTimetext.term = time1.text + ":" + time2.text;
                WantTimetext.regist_time(0);
                break;
            case 3:
                WantTimetext.deadline = time1.text + ":" + time2.text;
                WantTimetext.regist_time(1);
                break;
            case 4:
                WantTimetext.min = time1.text + ":" + time2.text;
                WantTimetext.regist_time(2);
                break;
            case 5:
                WantTimetext.max = time1.text + ":" + time2.text;
                WantTimetext.regist_time(3);
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

}
