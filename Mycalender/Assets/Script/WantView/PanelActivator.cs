using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//やりたいこと項目の左端"・・・"ボタンにアタッチ
public class PanelActivator : MonoBehaviour
{ 
    public static GameObject Panel;
    //詳細パネルを表示し値をセットする
    public void Active_Button()
    {
        Panel.SetActive(true);
        Panel.GetComponent<ViewPlanDetail>().wantplannumber = this.transform.parent.GetComponent<WantDetailNumber>().wantdetailnumber;
        Panel.GetComponent<ViewPlanDetail>().SetWantPlanDetail();
    }
    //詳細パネルを非表示にする
    public void Passive_Button()
    {
        Panel.SetActive(false);
    }
}
