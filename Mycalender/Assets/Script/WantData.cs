using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
//やりたいことの構造体WantData
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
    //文字列をTimeSpanおよびDateTime型に変換,1/24更新
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
