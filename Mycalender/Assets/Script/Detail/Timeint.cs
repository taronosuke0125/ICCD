using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timeint : MonoBehaviour
{

    public DateTime st;
    public DateTime ft;

    // Start is called before the first frame update
    void Start()
    {
        Data p = PlanList.DataList[this.GetComponent<DetailNumber>().detailnumber];
        st = p.Start;
        ft = p.Finish;
    }

    
}
