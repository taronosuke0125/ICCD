using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Updater : MonoBehaviour
{
    // Start is called before the first frame update    
    public Text Nametext;
    public Text Timetext;



    private void Start()
    {
        Debug.Log(this.GetComponent<DetailNumber>().detailnumber);
        Data p = PlanList.DataList[this.GetComponent<DetailNumber>().detailnumber];
        Nametext.text = p.Name;
        string s = p.Startstr.Substring(12, 5);
        string f = p.Finishstr.Substring(12, 5);
        Timetext.text = s + "～" + f;
        this.name = p.Name;
    }
}
