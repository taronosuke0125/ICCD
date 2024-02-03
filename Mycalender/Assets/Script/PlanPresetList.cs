using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class PlanPresetList:MonoBehaviour
{
    //�\��v���Z�b�g�̃��X�g�Ƃ��̗v�f��
    public static PlanPreset[] morning = new PlanPreset[60];
    public static int morningcn;
    public static PlanPreset[] lunch = new PlanPreset[60];
    public static int lunchcn;
    public static PlanPreset[] dinner = new PlanPreset[60];
    public static int dinnercn;
    private static bool onceflag = true;
    private void Start()
    {
        //�v���O��������񂾂����s
        if (onceflag)
        {
            morningcn=LoadPreset(morning, "morning.json");
            Debug.Log("loaded");
            ViewPlan(morning);            
        }
        
    }
    //�ۑ���̔z��Ƃ��̃t�@�C�����������Ɏw�肵�A�ǉ������v�f����Ԃ����\�b�h
    public static int LoadPreset(PlanPreset[] p, string filename)
    {
        string datastr = "";
        StreamReader reader;
        //�ǂݎ��ꏊ���w��
        Debug.Log(Application.dataPath + "/" + filename);
        reader = new StreamReader(Application.dataPath+"/"+filename);
        int datacount = 0;
        while (reader.Peek() != -1)
        {
            datastr = "{"+reader.ReadLine()+"}";//��s���ǂ�
            Debug.Log(datastr);
            //��s�ڂ̓^�O�Ȃ̂ŕۑ����Ȃ�
            if (datacount == 0)
            {
                datacount++;
                continue;
            }
            p[datacount-1] = JsonConvert.DeserializeObject<PlanPreset>(datastr);//�\��v���Z�b�g��\��v���Z�b�g���X�g�ɓo�^
            datacount++;
        }
        reader.Close();
        //�z��̗v�f����Ԃ�
        return datacount-1;
    }
    //�n���ꂽ�z��̗v�f�����ׂďo�͂���B
    public static void ViewPlan(PlanPreset[] p)
    {
        Debug.Log("veiw all preset");
        int i = 0;
        while (p[i] != null)
        {
            Debug.Log("i" + i);
            p[i].view();
        }
    }
}