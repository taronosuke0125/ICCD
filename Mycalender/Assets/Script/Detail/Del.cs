using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Del : MonoBehaviour
{
    //�{�^�����������Ƃ��ɌĂяo��(1/14�X�V)
    public void Pushdel(){
       DeletePlan();
        Debug.Log("pushdel");
    } 
    //�\����폜
    public void DeletePlan()
    {
        GameObject parent = transform.parent.gameObject;
        int number = parent.GetComponent<DetailNumber>().detailnumber;
        DeleteLine(number,0);
        PlanList.LoadPlan();
        PlanList.viewPlan();
        //���݂̃V�[���������[�h
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //��肽�����Ƃ��폜
    public void DeleteWantPlan()
    {
        GameObject parent = transform.parent.parent.gameObject;
        int number = parent.GetComponent<WantDetailNumber>().wantdetailnumber;
        DeleteLine(number, 1);
        WantPlanList.LoadWantPlan();
        WantPlanList.viewWantPlan();
        //���݂̃V�[���������[�h
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //json�t�@�C����n�s�ڂ��폜(n=0,1,2,3....),m=0�̂Ƃ��\����폜,m=1�̂Ƃ���肽�����Ƃ��폜
    public void DeleteLine(int n,int m)
    {
        int count = 0;
        //�t�@�C���̃p�X
        string filePath;
        if (m == 0)
           filePath = Application.persistentDataPath + "/savedata.json";//�\��
        else
           filePath = Application.persistentDataPath + "/savewantdata.json";//��肽������
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
            //�w�肵���s�ł���΁A��΂�
            if (count == n)
            {
                count++;
                continue;
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
}
