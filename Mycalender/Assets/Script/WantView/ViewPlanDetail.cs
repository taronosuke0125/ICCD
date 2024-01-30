using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewPlanDetail : MonoBehaviour
{
    //ï\é¶Ç∑ÇÈÇ‚ÇËÇΩÇ¢Ç±Ç∆ÇÃî‘çÜ
    public int wantplannumber;
    [SerializeField]
    TextMeshProUGUI title;
    [SerializeField]
    TextMeshProUGUI term;
    [SerializeField]
    TextMeshProUGUI deadlinedate;
    [SerializeField]
    TextMeshProUGUI deadlinetime;
    [SerializeField]
    TextMeshProUGUI min;
    [SerializeField]
    TextMeshProUGUI max;

    public void SetWantPlanDetail()
    {
        WantData p1 = WantPlanList.WantDataList[wantplannumber];
        title.text = p1.Name;
        term.text = p1.Termstr;
        deadlinedate.text = p1.DeadLine.ToString("yyyy/MM/dd");
        deadlinetime.text = p1.DeadLine.ToString("HH:mm");
        min.text = p1.minstr;
        max.text = p1.maxstr;
    }
   
}
