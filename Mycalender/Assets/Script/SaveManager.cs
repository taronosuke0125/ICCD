using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class SaveManager : MonoBehaviour
{
   /*
    public void savePlanData(Plan plan)
    {
        StreamWriter writer;
        string jsonstr = JsonUtility.ToJson(plan);

        writer = new StreamWriter(Application.persistentDataPath + "/savedata.json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    public Plan loadPlanData()
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(Application.persistentDataPath + "/savedata.json");
        datastr = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<Plan>(datastr);
    }

    public void Start()
    {
        Plan plan = new Plan();

        plan.setplanname("make curry");
        plan.setstartdate(DateTime.Now.ToString("yyyy/MM/dd"));
        plan.setfinishdate(DateTime.Now.AddDays(1).ToString("yyyy/MM/dd"));
        PlanList.planlist[0] = plan;
        savePlanData(PlanList.planlist[0]);
        Plan plan2 = loadPlanData();
        Debug.Log(plan2.getplanname());
        Debug.Log(plan2.getstartdate());
        Debug.Log(plan2.getfinishdate());

    }
   */
}
