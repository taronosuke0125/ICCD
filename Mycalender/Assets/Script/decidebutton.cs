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
    public void OnClickdecideButton()
    {
        //Debug.Log(inedit);
        if (inedit)
        {//予定編集時
            EditPlan(Edit.changenumber);
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
    //予定をjsonファイルに登録する
    private void RegistPlan()
    {
        DateTime start = setstartday.starttime.Date;
        DateTime finish = setstartday.finish.Date;
        Debug.Log("Start:"+start);
        Debug.Log("Finish:" + finish);
        start += TimeSpan.Parse(Timetext.starttime);
        finish += TimeSpan.Parse(Timetext.finishtime);
        Debug.Log("Startex:" + start);
        Debug.Log("Finishex:" + finish);
        Data schedule = new Data();
        schedule.Name = setstartday.planname;
        schedule.Startstr = start.ToString("yyyy/MM/dd/ HH:mm:ss");
        schedule.Finishstr = finish.ToString("yyyy/MM/dd/ HH:mm:ss");
        string jsonschedule = JsonUtility.ToJson(schedule);
        string path = Application.persistentDataPath + "/savedata.json"; /* 既存のJSONファイルのパス */
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(jsonschedule);
        writer.Close();
        //予定を登録したら時間を初期化
        Timetext.starttime = "00:00";
        Timetext.finishtime = "00:00";
    }
    //1/16更新 jsonファイルn行目の予定を書き換える
    private void EditPlan(int n)
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
        string filePath = Application.persistentDataPath+ "/savedata.json";
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
        //予定を登録したら時間を初期化
        Timetext.starttime = "00:00";
        Timetext.finishtime = "00:00";
    }
}