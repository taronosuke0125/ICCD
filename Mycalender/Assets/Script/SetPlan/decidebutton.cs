using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class decidebutton : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool inedit=false;
    //SetPlanの登録ボタンにアタッチ
    public void OnClickdecideButton()
    {
        //Debug.Log(inedit);
        if (inedit)
        {//予定編集時
            RegistPlan(Edit.changenumber);
            //予定リストを再読み込み
            PlanList.LoadPlan();
            InputPlantitle.DeleteNameStatic();
            inedit = false;
            SceneManager.LoadScene("detail");
        }
        else
        {//予定登録時
            RegistPlan();
            InputPlantitle.DeleteNameStatic();
            SceneManager.LoadScene("Calender");
        }
    }
    //WantSetシーンの登録ボタンにアタッチ
    public void OnClickdecideButtonForWant()
    {
        if (inedit)
        {//やりたいことリスト編集時
            RegistWantPlan(Edit.changenumber);
            inedit = false;
        }
        else
        {//やりたいこと登録時
            RegistWantPlan();
        }
        InputWantPlanTitle.DeleteNameStatic();
        SceneManager.LoadScene("WantView");
    }
    
    //1/28更新 jsonファイルn行目の予定を書き換える、登録と編集のメソッドを共通化(n<0なら登録、それ以外ならn行目の予定を編集)
    private void RegistPlan(int n=-1)
    {
        DateTime start = setstartday.starttime.Date;
        DateTime finish = setstartday.finish.Date;
        start += TimeSpan.Parse(Timetext.starttime);
        finish += TimeSpan.Parse(Timetext.finishtime);
        Data schedule = new Data();
        schedule.Name = setstartday.planname;
        schedule.Startstr = start.ToString("yyyy/MM/dd/ HH:mm:ss");
        schedule.Finishstr = finish.ToString("yyyy/MM/dd/ HH:mm:ss");
        string jsonschedule = JsonUtility.ToJson(schedule);
        int count = 0;
        //ファイルのパス
        string filePath = Application.persistentDataPath + "/savedata.json";
        
        if (n < 0) 
        {
            StreamWriter writer = new StreamWriter(filePath, true);
            writer.WriteLine(jsonschedule);
            writer.Close();
        }
        else
        {
            //ファイルを読み込みで開く
            System.IO.StreamReader sr = new System.IO.StreamReader(filePath);

            //一時ファイルを作成する
            string tmpPath = System.IO.Path.GetTempFileName();
            //一時ファイルを書き込みで開く
            System.IO.StreamWriter sw = new System.IO.StreamWriter(tmpPath);

            //内容を一行ずつ読み込む
            while (sr.Peek() > -1)
            {
                //一行読み込む
                string line = sr.ReadLine();
                //指定した行であれば、編集した予定を格納する
                if (count == n)
                {
                    line = jsonschedule;
                }
                //一時ファイルに書き込む
                sw.WriteLine(line);
                count++;
            }
            //閉じる
            sr.Close();
            sw.Close();
            //一時ファイルと入れ替える
            System.IO.File.Copy(tmpPath, filePath, true);
            System.IO.File.Delete(tmpPath);
        }
        //予定を登録したら時間を初期化
        Timetext.starttime = "00:00";
        Timetext.finishtime = "00:00";
    }

    //やりたいことリストを登録or編集
    public void RegistWantPlan(int n=-1)
    {
        DateTime deadline = setdeadline.deadline.Date;
        deadline += TimeSpan.Parse(WantTimeText.deadlinetime);
        WantData schedule = new WantData();
        schedule.Name = setdeadline.wantplanname;
        Debug.Log(setdeadline.wantplanname);
        Debug.Log(schedule.Name);
        schedule.Termstr = WantTimeText.term;
        schedule.DeadLinestr = deadline.ToString("yyyy/MM/dd/ HH:mm:ss");
        schedule.maxstr=WantTimeText.max;
        schedule.minstr = WantTimeText.min;
        string jsonschedule = JsonUtility.ToJson(schedule);
        int count = 0;
        //ファイルのパス
        string filePath = Application.persistentDataPath + "/savewantdata.json";
        Debug.Log(filePath);
        if (n < 0)
        {
            StreamWriter writer = new StreamWriter(filePath, true);
            writer.WriteLine(jsonschedule);
            writer.Close();
        }
        else
        {
            //ファイルを読み込みで開く
            System.IO.StreamReader sr = new System.IO.StreamReader(filePath);
            //一時ファイルを作成する
            string tmpPath = System.IO.Path.GetTempFileName();
            //一時ファイルを書き込みで開く
            System.IO.StreamWriter sw = new System.IO.StreamWriter(tmpPath);

            //内容を一行ずつ読み込む
            while (sr.Peek() > -1)
            {
                //一行読み込む
                string line = sr.ReadLine();
                //指定した行であれば、編集した予定を格納する
                if (count == n)
                {
                    line = jsonschedule;
                }
                //一時ファイルに書き込む
                sw.WriteLine(line);
                count++;
            }
            //閉じる
            sr.Close();
            sw.Close();
            //一時ファイルと入れ替える
            System.IO.File.Copy(tmpPath, filePath, true);
            System.IO.File.Delete(tmpPath);
        }
        //予定を登録したら時間を初期化
        WantTimeText.deadlinetime = "00:00";
        
    }
}