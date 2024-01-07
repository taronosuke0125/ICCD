using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SetTitle : MonoBehaviour
{
    //日付取得用
    public static DateTime SelectDate;
    
    //基本的に他のメソッドに呼び出される形で使用する。
    public void TitleController(DateTime SelectDate)
    {
        this.transform.GetChild(0).GetComponent<Text>().text = SelectDate.ToString("yyyy/MM/dd");
    }
    // Start is called before the first frame update
    
}
