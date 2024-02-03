using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanPreset 
{//予定プリセット用のクラス
    public int ID;
    public string name;
    public string detail;
    public void view()
    {
        Debug.Log("ID:" + ID+", Name:"+name);
    }
}
