using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class WantPlanList : MonoBehaviour
{
    public static WantData[] WantDataList = new WantData[99];//��肽�����Ƃ̃��X�g
    public static int wantdatacount;//��肽�����Ƃ̌�

    public static void LoadWantPlan()
    {
        string datastr = "";
        StreamReader reader;
        //�ǂݎ��ꏊ���w��
        Debug.Log(Application.persistentDataPath);
        reader = new StreamReader(Application.persistentDataPath + "/savewantdata.json");
        wantdatacount = 0;
        while (reader.Peek() != -1)
        {
            datastr = reader.ReadLine();//��s���ǂ�
            WantDataList[wantdatacount] = JsonConvert.DeserializeObject<WantData>(datastr);//��肽�����Ƃ���肽�����ƃ��X�g�ɓo�^
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
        //�ŏ���savewantdata��ǂݍ��݃��X�g���쐬����
        LoadWantPlan();
        viewWantPlan();
    }
}
