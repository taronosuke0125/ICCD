using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputPlantitle : MonoBehaviour
{
    public static TMP_InputField Name;
    public static string staticname;
    private void Start()
    {
        Name = GameObject.Find("InputPlanName").GetComponent<TMP_InputField>();
        Name.text = staticname;
    }
    //Inputboxで文字を入力したらplannameに保存
    public void EnteredPlanName()
    {
        staticname = Name.text;
        setstartday.planname = Name.text;
        Debug.Log(setstartday.planname);
    }
    //登録したらstaticnameを初期化
    public static void DeleteNameStatic()
    {
        staticname = null;
    }
}
