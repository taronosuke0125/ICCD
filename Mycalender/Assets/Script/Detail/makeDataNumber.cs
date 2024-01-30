using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeDataNumber : MonoBehaviour
{
    public static int[] PlanNumberList=new int[10];
    public static int Listcount;
    public int i;
    private void Start()
    {

        //—\’è”Ô†ƒŠƒXƒg‚Ìì¬
        SetPlanNumber();
        for(i=0; i<Listcount; i++)
        {
            PlanList.DataList[PlanNumberList[i]].view();
        }
    }
    //PlanNumberList‚ÉToDate‚ğŠÜ‚Ş—\’è‚Ì”Ô†‚ğŠi”[‚·‚é.
   public void SetPlanNumber()
    {
        Listcount = 0;
        for(i=0; i<PlanList.datacount; i++)
        {
            if (PlanList.DataList[i].Start.Date <=CreateDate.ToDate.Date && CreateDate.ToDate.Date <= PlanList.DataList[i].Finish.Date)
            {
                PlanNumberList[Listcount++] = i;
                Debug.Log("PlanNumber:"+i);
            }
        }
    }
}
