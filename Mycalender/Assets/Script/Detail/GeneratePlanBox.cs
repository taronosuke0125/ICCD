using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlanBox : MonoBehaviour
{
    //登録された予定の和だけ予定のボックスを作成
    public GameObject canvas;
    public GameObject prefab;
    void Start()
    {
        //登録された予定の数だけdetailプレハブを作成
        for (int i = 0; i < makeDataNumber.Listcount ; i++)
        {
            GameObject planbox = Instantiate(prefab, canvas.transform);
            planbox.GetComponent<DetailNumber>().detailnumber = makeDataNumber.PlanNumberList[i];
            Debug.Log("this Detail Number:"+planbox.GetComponent<DetailNumber>().detailnumber);
        }
    }
}
