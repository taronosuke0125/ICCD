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
    //�\��v���Z�b�g���������e�L�X�g�t�@�C��
    public TextAsset morning_text;
    public TextAsset lunch_text;
    public TextAsset dinner_text;
    private static bool onceflag = true;
    private void Start()
    {
        //�v���O��������񂾂����s
        if (onceflag)
        {
            morningcn=LoadPreset(morning, morning_text);
            ViewPlan(morning);
            lunchcn = LoadPreset(lunch, lunch_text);
            ViewPlan(lunch);
            dinnercn = LoadPreset(dinner, dinner_text);
            ViewPlan(dinner);
            onceflag = false;
        }
        
    }
    //�ۑ���̔z��ƌ��̃e�L�X�g�t�@�C���������Ɏw�肵�A�ǉ������v�f����Ԃ����\�b�h
    public static int LoadPreset(PlanPreset[] p, TextAsset dish_text)
    {
        string datastr = "";
        //�ǂݎ��e�L�X�g���w��
        StringReader reader = new StringReader(dish_text.text);
        
        int datacount = 0;
        
        while (reader.Peek() != -1)
        {
            datastr = reader.ReadLine();//��s���ǂ�
            datastr = "{" + datastr + "}";
            //��s�ڂ̓^�O�Ȃ̂ŕۑ����Ȃ�
            if (datacount == 0)
            {
                datacount++;
                continue;
            }
            p[datacount-1] = JsonConvert.DeserializeObject<PlanPreset>(datastr);//�\��v���Z�b�g��\��v���Z�b�g���X�g�ɓo�^
            datacount++;
        }
        p[datacount-1]=null;
        reader.Close();
        //�z��̗v�f����Ԃ�
        return datacount-1;
    }
    //�n���ꂽ�z��̗v�f�����ׂďo�͂���B
    public static void ViewPlan(PlanPreset[] p)
    {
        Debug.Log("veiw all preset");
        int i;
        for(i=0; p[i]!= null; i++)
        {
            p[i].view();
        }
    }
}