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
        //—\’è”Ô†ƒŠƒXƒg‚Ì‰Šú‰»
        for(i=0; i<10; i++)
        {

        }
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
        for(i=0; i<PlanList.datacount; i++)
        {
            if (PlanList.DataList[i].Start <=CreateDate.ToDate.Date && CreateDate.ToDate.Date <= PlanList.DataList[i].Finish)
            {
                PlanNumberList[Listcount++] = i;
                Debug.Log("PlanNumber:"+i);
            }
        }
    }
}
