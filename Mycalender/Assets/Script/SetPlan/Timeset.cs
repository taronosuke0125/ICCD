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
    private GameObject ErrorText;
    private static int flag;//0�Ȃ�starttime�ɋL�^�A1�Ȃ�finishtime�ɋL�^�A2�Ȃ�term�A3�Ȃ�min�A4�Ȃ�max(1/24�X�V)
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
        if(count != 4)
        {//���Ԃ�4�����͂��Ă��Ȃ��Ƃ��̓G���[����3�b�ԕ\����Enter���������B
            ErrorText.GetComponent<TextMeshProUGUI>().text = "#���͂��s�\���ł�";
            StartCoroutine(ShowSecond(ErrorText, 3f));
            return;
        }

        //TimeSpan�ɓ���鎞�Ԃ𐮐��ɕϊ�
        int time = int.Parse(time1.text) * 100 + int.Parse(time2.text);
        switch (flag)
        {
            //0�Ȃ�starttime�ɋL�^�A1�Ȃ�finishtime�A2�Ȃ�term�A3�Ȃ�deadline�A4�Ȃ�min�A5�Ȃ�max�ɋL�^(2/12�X�V)
            case 0:
                if (OverFlowChecker(0))
                {
                    ErrorDateTime();
                    return;
                }
                Timetext.starttime = time1.text + ":" + time2.text;
                Timetext.regist_time();
                break;
            case 1:
                if (OverFlowChecker(0))
                {
                    ErrorDateTime();
                    return;
                }
                Timetext.finishtime = time1.text + ":" + time2.text;
                Timetext.regist_time();
                break;
            case 2:
                if (OverFlowChecker(1))
                {
                    ErrorDateTime();
                    return;
                }
                WantTimeText.term = time;
                GameObject.Find("RegistManager").GetComponent<WantTimeText>().regist_time(0);
                break;
            case 3:
                if (OverFlowChecker(0))
                {
                    ErrorDateTime();
                    return;
                }
                WantTimeText.deadlinetime = time1.text + ":" + time2.text;
                GameObject.Find("RegistManager").GetComponent<WantTimeText>().regist_time(1);
                break;
            case 4:
                if (OverFlowChecker(1))
                {
                    ErrorDateTime();
                    return;
                }
                WantTimeText.min = time;
                GameObject.Find("RegistManager").GetComponent<WantTimeText>().regist_time(2);
                break;
            case 5:
                if (OverFlowChecker(1))
                {
                    ErrorDateTime();
                    return;
                }
                WantTimeText.max = time;
                GameObject.Find("RegistManager").GetComponent<WantTimeText>().regist_time(3);
                break;
        }
        Return_Button();
        Debug.Log("Excuted");
    }
    //�{�^���������ƃ{�^���p�l����\������    
    public void Active_Button(int i)
    {
        flag = i;
        Panel.SetActive(true);
    }
    //DateTime�ł�24:00�ȏ�,TimeSpan�ł�999:59���傫�����͂��^�����Ă��邩�m�F���郁�\�b�h(i=0��DateTime,i=1��TimeSpan)
    public bool OverFlowChecker(int i)
    {
        int hours = int.Parse(time1.text);
        int minutes = int.Parse(time2.text);
        if (i == 0)
        {
            if (hours > 23 || minutes > 59)
            {
                return true;
            }
        }
        else
        {
            if (minutes > 59)
            {
                return true;
            }
        }
        
        return false;
    }
    //DateTime�̕s���Ɋւ��ăG���[�\�����s�����\�b�h
    public void ErrorDateTime()
    {
        ErrorText.GetComponent<TextMeshProUGUI>().text= "#�K�؂Ȏ��Ԃ���͂��Ă�������";
        StartCoroutine(ShowSecond(ErrorText, 3f));
    }
    // �����ŗ^����ꂽ�I�u�W�F�N�g��\�����A�����̕b����ɔ�\���ɂ���R���[�`��
    IEnumerator ShowSecond(GameObject targetObj, float sec)
    {
        targetObj.SetActive(true); //�����Ŏw�肳�ꂽ�I�u�W�F�N�g��\������
        yield return new WaitForSeconds(sec); // �����Ŏw�肳�ꂽ�b���҂�
        targetObj.SetActive(false); //�����Ŏw�肳�ꂽ�I�u�W�F�N�g���\���ɂ���
    }
}
