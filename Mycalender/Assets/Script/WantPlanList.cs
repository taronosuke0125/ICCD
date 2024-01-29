using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class WantPlanList : MonoBehaviour
{
    public static WantData[] WantDataList = new WantData[99];//やりたいことのリスト
    public static int wantdatacount;//やりたいことの個数

    public static void LoadWantPlan()
    {
        string datastr = "";
        StreamReader reader;
        //読み取り場所を指定
        Debug.Log(Application.persistentDataPath);
        reader = new StreamReader(Application.persistentDataPath + "/savewantdata.json");
        wantdatacount = 0;
        while (reader.Peek() != -1)
        {
            datastr = reader.ReadLine();//一行ずつ読む
            WantDataList[wantdatacount] = JsonConvert.DeserializeObject<WantData>(datastr);//やりたいことをやりたいことリストに登録
            WantDataList[wantdatacount].IntToString();
            wantdatacount++;
        }
        reader.Close();
    }

    public static void viewWantPlan()
    {
        int i;
        Debug.Log("wantdatacount:" + wantdatacount);
        for (i = 0; i < wantdatacount; i++)
            WantDataList[i].view();
    }


    private void Start()
    {
        //最初にsavewantdataを読み込みリストを作成する
        LoadWantPlan();
        viewWantPlan();
    }
}
