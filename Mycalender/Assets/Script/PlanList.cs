using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class PlanList : MonoBehaviour
{
    public static Data[] DataList=new Data[99];//�\��̃��X�g
    public static int datacount;//�\��̌�
    public static void LoadPlan()
    {
        string datastr = "";
        StreamReader reader;
        //�ǂݎ��ꏊ���w��
        Debug.Log(Application.persistentDataPath);
        reader = new StreamReader(Application.persistentDataPath + "/savedata.json");
        datacount = 0;
        while (reader.Peek() != -1)
        {
            datastr = reader.ReadLine();//��s���ǂ�
            DataList[datacount]=JsonConvert.DeserializeObject<Data>(datastr);//�\���\�胊�X�g�ɓo�^
            DataList[datacount].IntToString();
            datacount++;
        }
        reader.Close();
    }

    public static void viewPlan()
    {
        int i;
        Debug.Log("datacount:"+datacount);
        for (i = 0; i < datacount; i++)
            DataList[i].view();
    }


    private void Start()
    {
        //�ŏ���savedata��ǂݍ��݃��X�g���쐬����
        LoadPlan();
        viewPlan();
    }
}
