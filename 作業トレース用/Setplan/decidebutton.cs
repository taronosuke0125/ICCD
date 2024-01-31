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
    //SetPlan�̓o�^�{�^���ɃA�^�b�`
    public void OnClickdecideButton()
    {
        //Debug.Log(inedit);
        if (inedit)
        {//�\��ҏW��
            RegistPlan(Edit.changenumber);
            //�\�胊�X�g���ēǂݍ���
            PlanList.LoadPlan();
            InputPlantitle.DeleteNameStatic();
            inedit = false;
            SceneManager.LoadScene("detail");
        }
        else
        {//�\��o�^��
            RegistPlan();
            InputPlantitle.DeleteNameStatic();
            SceneManager.LoadScene("Calender");
        }
    }
    //WantSet�V�[���̓o�^�{�^���ɃA�^�b�`
    public void OnClickdecideButtonForWant()
    {
        if (inedit)
        {//��肽�����ƃ��X�g�ҏW��
            RegistWantPlan(Edit.changenumber);
            inedit = false;
        }
        else
        {//��肽�����Ɠo�^��
            RegistWantPlan();
        }
        InputWantPlanTitle.DeleteNameStatic();
        SceneManager.LoadScene("WantView");
    }
    
    //1/28�X�V json�t�@�C��n�s�ڂ̗\�������������A�o�^�ƕҏW�̃��\�b�h�����ʉ�(n<0�Ȃ�o�^�A����ȊO�Ȃ�n�s�ڂ̗\���ҏW)
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
        //nagi edited
        schedule.memo = GameObject.Find("InputField").GetComponent<Memoedit>().smemo;
        //end
        string jsonschedule = JsonUtility.ToJson(schedule);
        int count = 0;
        //�t�@�C���̃p�X
        string filePath = Application.persistentDataPath + "/savedata.json";
        
        if (n < 0) 
        {
            StreamWriter writer = new StreamWriter(filePath, true);
            writer.WriteLine(jsonschedule);
            writer.Close();
        }
        else
        {
            //�t�@�C����ǂݍ��݂ŊJ��
            System.IO.StreamReader sr = new System.IO.StreamReader(filePath);

            //�ꎞ�t�@�C�����쐬����
            string tmpPath = System.IO.Path.GetTempFileName();
            //�ꎞ�t�@�C�����������݂ŊJ��
            System.IO.StreamWriter sw = new System.IO.StreamWriter(tmpPath);

            //���e����s���ǂݍ���
            while (sr.Peek() > -1)
            {
                //��s�ǂݍ���
                string line = sr.ReadLine();
                //�w�肵���s�ł���΁A�ҏW�����\����i�[����
                if (count == n)
                {
                    line = jsonschedule;
                }
                //�ꎞ�t�@�C���ɏ�������
                sw.WriteLine(line);
                count++;
            }
            //����
            sr.Close();
            sw.Close();
            //�ꎞ�t�@�C���Ɠ���ւ���
            System.IO.File.Copy(tmpPath, filePath, true);
            System.IO.File.Delete(tmpPath);
        }
        //�\���o�^�����玞�Ԃ�������
        Timetext.starttime = "00:00";
        Timetext.finishtime = "00:00";
    }

    //��肽�����ƃ��X�g��o�^or�ҏW
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
        //�t�@�C���̃p�X
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
            //�t�@�C����ǂݍ��݂ŊJ��
            System.IO.StreamReader sr = new System.IO.StreamReader(filePath);
            //�ꎞ�t�@�C�����쐬����
            string tmpPath = System.IO.Path.GetTempFileName();
            //�ꎞ�t�@�C�����������݂ŊJ��
            System.IO.StreamWriter sw = new System.IO.StreamWriter(tmpPath);

            //���e����s���ǂݍ���
            while (sr.Peek() > -1)
            {
                //��s�ǂݍ���
                string line = sr.ReadLine();
                //�w�肵���s�ł���΁A�ҏW�����\����i�[����
                if (count == n)
                {
                    line = jsonschedule;
                }
                //�ꎞ�t�@�C���ɏ�������
                sw.WriteLine(line);
                count++;
            }
            //����
            sr.Close();
            sw.Close();
            //�ꎞ�t�@�C���Ɠ���ւ���
            System.IO.File.Copy(tmpPath, filePath, true);
            System.IO.File.Delete(tmpPath);
        }
        //�\���o�^�����玞�Ԃ�������
        WantTimeText.deadlinetime = "00:00";
        
    }
}