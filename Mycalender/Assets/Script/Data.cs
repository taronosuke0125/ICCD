using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//ó\íËÇÃç\ë¢ëÃData
public class Data
{
    public string Name;
    public int StartY;
    public int StartM;        
    public int StartD;
    public int FinishY;
    public int FinishM;
    public int FinishD;
    public void view()
    {
        Debug.Log("Name:" + Name + ", StartY:" + StartY + ", StartM:" + StartM + ", StartD:" + StartD + ", FinishY:" + FinishY + ", FinishM:" + FinishM + ", FinishD:" + FinishD);
    }
}
public class DataPro : Data
{
    public DateTime Start;
    public DateTime Finish;
}
