using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Plan
{
    public string planname;
    public string plandate;

    public void setplanname(string name)
    {
        planname = name;
    }
    public string getplanname()
    {
        return planname;
    }
   public void setplandate(string date)
    {
        plandate = date;
    }
    public string getplandate()
    {
        return plandate;
    }
    public void setplan(Plan plan1)
    {
        setplanname(plan1.planname);
        setplandate(plan1.plandate);
    }
}
