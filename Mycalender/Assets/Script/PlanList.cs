using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanList:MonoBehaviour
{

    public static Plan[] planlist = new Plan[99];
    public static int plancount = 0;
    public static void setplan(Plan plan)
    {
        planlist[plancount] = plan;
        plancount++;
    }
}
