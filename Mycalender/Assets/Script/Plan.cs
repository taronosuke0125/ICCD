using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using System;

public class Plan
{
    public string planname;//�\��̖��O
    public string startdate;//�\��̊J�n����
    public string finishdate;//�\��̏I������
    public string plandetail;//�\��̏ڍ�

    public void setplanname(string name)
    {
        planname = name;
    }
    public string getplanname()
    {
        return planname;
    }
   public void setstartdate(string date)
    {
        startdate = date;
    }

    public void setfinishdate(string date)
    {
        finishdate = date;
    }

    public DateTime getstartdate()
    {
        return DateTime.Parse(startdate);
    }
    public DateTime getfinishdate()
    {
        return DateTime.Parse(finishdate);
    }
    public void setplan(string name,string start,string finish)
    {
        setplanname(name);
        setstartdate(start);
        setfinishdate(finish);
    }
}
