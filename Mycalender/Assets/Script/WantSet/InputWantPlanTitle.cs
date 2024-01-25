using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputWantPlanTitle : MonoBehaviour
{
    public static TMP_InputField Name;
    public static string staticname;
    private void Start()
    {
        Name = GameObject.Find("InputWantPlanName").GetComponent<TMP_InputField>();
        Name.text = staticname;
    }
    //Inputboxで文字を入力したらwantplannameに保存
    public void EnteredWantPlanName()
    {
        staticname = Name.text;
        //setstartday.planname = Name.text;
        Debug.Log(staticname);
    }
    //登録したらstaticnameを初期化
    public static void DeleteNameStatic()
    {
        staticname = null;
    }
}
