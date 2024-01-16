using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Edit : MonoBehaviour
{
    //編集する予定の番号
    public static int changenumber;
    //編集モードに切り替えたSetPlanシーンに遷移
    public void EditB(){
        GameObject parent = transform.parent.gameObject;
        //編集する予定の番号を記録
        changenumber = parent.GetComponent<DetailNumber>().detailnumber;
        //SetPlanのEditモード
        decidebutton.inedit = true;
        startday.changeflug = 3;
        //表示する予定の名前を変更前のものにする
        string name = PlanList.DataList[changenumber].Name;
        setstartday.planname = name;
        InputPlantitle.staticname = name;
        SceneManager.LoadScene("SetPlan");
    }
}
