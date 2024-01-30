using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using System;
using TMPro;
public class Timeset : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI time1;
    [SerializeField]
    private TextMeshProUGUI time2;
    [SerializeField]
    private GameObject Panel;
    [SerializeField]

    private static int flag;//0�Ȃ�starttime�ɋL�^�A1�Ȃ�finishtime�ɋL�^
    public static int count=0;
    //�{�^���������Ƃ��̃{�^���ɓo�^���ꂽ������ǉ�����time�ɏo��
    public void Push_Button(int number)
    {
        if (count < 2)
        {
            time1.text += number;
            count++;
        }else if(count<4)
        {
            time2.text += number;
            count++;
        }
        Debug.Log("count:" + count);

    }
    //�{�^���������Ɩ���1�����폜
    public void Delete_Button()
    {
        if (count > 2)
        {   
            int num=time2.text.Length-1;
            time2.text=time2.text.Remove(num,1);
            count--;
        }
        else if(count>0)
        {
            int num = time1.text.Length - 1;
            time1.text=time1.text.Remove(num, 1);
            count--;
        }
    }
    //�{�^���������ƌ��ݎ�������͂���
    public void Now_Button()
    {
        string hour = DateTime.Now.ToString("HH");
        string minutes= DateTime.Now.ToString("mm");
        time1.text = hour;
        time2.text = minutes;
        count = 4;
    }
    //�{�^���������Ɠ��͂�S�폜����
    public void Clear_Button()
    {
        time1.text = "";
        time2.text = "";
        count = 0;
    }
    //�{�^���������ƃ{�^���p�l�����\���ɂ���
    public void Return_Button()
    {
        Clear_Button();
        this.gameObject.transform.parent.parent.parent.gameObject.SetActive(false);
    }
    //�{�^���������ƕ\������Ă��鎞�Ԃ��i�[����
    public void Enter_Button()
    {
        if (flag == 0)
        {
            Timetext.starttime = time1.text + ":" + time2.text;
            Timetext.regist_time();
            Return_Button();
        }
        else
        {
            Timetext.finishtime = time1.text + ":" + time2.text;
            Timetext.regist_time();
            Return_Button();
        }
    }
    //�{�^���������ƃ{�^���p�l����\������    
    public void Active_Button(int i)
    {
        flag = i;
        Panel.SetActive(true);
    }

}
