using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class WantTimetext : MonoBehaviour
{
    public static string term = "12:00";//Timeset.cs�œ��͂��ꂽ���Ԃ��i�[
    public static string deadline = "13:00";//Timeset.cs�œ��͂��ꂽ���Ԃ��i�[
    public static string min = "15:00";//Timeset.cs�œ��͂��ꂽ���Ԃ��i�[
    public static string max = "18:00";//Timeset.cs�œ��͂��ꂽ���Ԃ��i�[

    // Start is called before the first frame update
    void Start()
    {
        regist_time(0); regist_time(1); regist_time(2); regist_time(3);
    }
    //�n���ꂽ���Ԃ�o�^��ʂɕ\������
    public static void regist_time(int number)
    {
        if (number == 0)
            GameObject.Find("TermTime").GetComponent<TextMeshProUGUI>().text = term;
        if (number == 1)
            GameObject.Find("DLTime").GetComponent<TextMeshProUGUI>().text = deadline;
        if (number==2)
            GameObject.Find("MinTime").GetComponent<TextMeshProUGUI>().text = min;
        if (number==3)
            GameObject.Find("MaxTime").GetComponent<TextMeshProUGUI>().text = max;
    }
}
