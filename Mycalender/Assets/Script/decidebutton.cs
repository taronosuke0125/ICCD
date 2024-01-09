using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class decidebutton : MonoBehaviour
{
  
    public class Data
    {
     public int StartY;
     public int StartM;
     public int StartD;
     public int FinishY;
     public int FinishM;
     public int FinishD;
    }
    // Start is called before the first frame update
    public void OnClickdecideButton()
    {
        DateTime starttime = setstartday.starttime;
        DateTime finish = setstartday.finish;
        Data schedule = new Data();
        schedule.StartY = int.Parse(starttime.ToString("yyyy"));
        schedule.StartM = int.Parse(starttime.ToString("MM"));
        schedule.StartD = int.Parse(starttime.ToString("dd"));
        schedule.FinishY = int.Parse(finish.ToString("yyyy"));
        schedule.FinishM = int.Parse(finish.ToString("MM"));
        schedule.FinishD = int.Parse(finish.ToString("dd"));
        string jsonschedule = JsonUtility.ToJson(schedule);
        Debug.Log(jsonschedule);
        string path = Application.dataPath + "/savedata.json"; /* 既存のJSONファイルのパス */
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(jsonschedule);
        writer.Close();


        SceneManager.LoadScene("Calender");
    }
}