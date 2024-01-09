using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlanList
{
    public static Plan[] planlist = new Plan[99];
    public static int plancount = 0;
    public static void setplan(Plan plan)
    {
        planlist[plancount] = plan;
        plancount++;
    }
}
