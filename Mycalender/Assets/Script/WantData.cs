using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
//��肽�����Ƃ̍\����WantData
public class WantData
{
    public string Name;
    public string Termstr;
    public string DeadLinestr;
    public string minstr;
    public string maxstr;
    public TimeSpan Term;
    public DateTime DeadLine;
    public TimeSpan min;
    public TimeSpan max;
    public void view()
    {
        Debug.Log("Name:" + Name + ",Term:" + Term + ",DeadLine:" + DeadLine + "Min:" + min + "Max:" + max);
    }
    //�������TimeSpan�����DateTime�^�ɕϊ�,1/24�X�V
    public void IntToString()
    {
        Term = TimeSpan.Parse(Termstr);
        CultureInfo provider = CultureInfo.InvariantCulture;
        string format = "yyyy/MM/dd/ HH:mm:ss";
        DeadLine = DateTime.ParseExact(DeadLinestr, format, provider);
        min = TimeSpan.Parse(minstr); 
        max = TimeSpan.Parse(maxstr);
    }

}
