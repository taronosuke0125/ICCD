using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Edit : MonoBehaviour
{
    //�ҏW����\��̔ԍ�
    public static int changenumber;
    //�ҏW���[�h�ɐ؂�ւ���SetPlan�V�[���ɑJ��
    public void EditB(){
        GameObject parent = transform.parent.gameObject;
        //�ҏW����\��̔ԍ����L�^
        changenumber = parent.GetComponent<DetailNumber>().detailnumber;
        //SetPlan��Edit���[�h
        decidebutton.inedit = true;
        startday.changeflug = 3;
        //�\������\��̖��O��ύX�O�̂��̂ɂ���
        string name = PlanList.DataList[changenumber].Name;
        setstartday.planname = name;
        InputPlantitle.staticname = name;
        SceneManager.LoadScene("SetPlan");
    }
}
