using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateWantPlanBox : MonoBehaviour
{
    public GameObject canvas;
    public GameObject prefab;
    //登録されたやりたいことの数だけやりたいことのボックスを作成。
    public void Start()
    {
        //登録されたやりたいことの数だけWantPlanPanelプレハブを作成
        for (int i = 0; i < WantPlanList.wantdatacount; i++)
        {
            GameObject planbox = Instantiate(prefab, canvas.transform);
            planbox.GetComponent<WantDetailNumber>().wantdetailnumber = i;
            planbox.transform.GetChild(1).GetComponent<Text>().text = WantPlanList.WantDataList[i].Name;
            Debug.Log("this Detail Number:" + planbox.GetComponent<WantDetailNumber>().wantdetailnumber);
        }
    }
}
