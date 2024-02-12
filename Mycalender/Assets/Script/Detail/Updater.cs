using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Updater : MonoBehaviour
{
    // Start is called before the first frame update    
    public TextMeshProUGUI Nametext;
    public TextMeshProUGUI Timetext;

    private void Start()
    {
        Debug.Log(this.GetComponent<DetailNumber>().detailnumber);
        Data p = PlanList.DataList[this.GetComponent<DetailNumber>().detailnumber];
        Nametext.text = p.Name;
        DateTime date = CreateDate.ToDate;
        Debug.Log(date);
        if (p.Start.Date == date.Date && p.Finish.Date == date.Date)
        {
            string s = p.Startstr.Substring(12, 5);
            string f = p.Finishstr.Substring(12, 5);
            Timetext.text = s + "Å`" + f;
        }else if (p.Start.Date == date.Date)
        {
            string s = p.Startstr.Substring(12, 5);
            Timetext.text = s+"Å`";
        }else if (p.Finish.Date == date.Date)
        {
            string f = p.Finishstr.Substring(12, 5);
            Timetext.text = "Å`" + f;
        }
    }
}
