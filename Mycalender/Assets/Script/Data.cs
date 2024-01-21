using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;

//—\’è‚Ì\‘¢‘ÌData
public class Data
{
    public string Name;
    public string Startstr;
    public string Finishstr;
    public DateTime Start;
    public DateTime Finish;
    public void view()
    {
        Debug.Log("Name:" + Name + ",Start:"+Start+"Finish:"+Finish);
    }
    //•¶š—ñ‚ğDateTimeŒ^‚É•ÏŠ·,1/21XV
    public void IntToString()
    {
        CultureInfo provider = CultureInfo.InvariantCulture;
        string format= "yyyy/MM/dd/ HH:mm:ss";
        Start = DateTime.ParseExact(Startstr,format,provider);
        Finish = DateTime.ParseExact(Finishstr,format,provider);
    }

}
