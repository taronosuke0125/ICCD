using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//��肽�����ƍ��ڂ̍��["�E�E�E"�{�^���ɃA�^�b�`
public class PanelActivator : MonoBehaviour
{ 
    public static GameObject Panel;
    //�ڍ׃p�l����\�����l���Z�b�g����
    public void Active_Button()
    {
        Panel.SetActive(true);
        Panel.GetComponent<ViewPlanDetail>().wantplannumber = this.transform.parent.GetComponent<WantDetailNumber>().wantdetailnumber;
        Panel.GetComponent<ViewPlanDetail>().SetWantPlanDetail();
    }
    //�ڍ׃p�l�����\���ɂ���
    public void Passive_Button()
    {
        Panel.SetActive(false);
    }
}
