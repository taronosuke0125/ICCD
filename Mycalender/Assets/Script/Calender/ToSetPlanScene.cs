using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ToSetPlanScene : MonoBehaviour
{
    public void OnClickAddButton()
    {
        SceneManager.LoadScene("SetPlan");
    }
    public void OnClickAddButtonDate()
    {
        //日程横のプラスボタンを押すとSetPlanシーンへ遷移
        startday.changeflug = 100;
        CreateDate.SelectDate = transform.parent.GetComponent<ButtonDate>().day;
        SceneManager.LoadScene("SetPlan");
    }
}
