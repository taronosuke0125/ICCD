using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GeneratePlanBox : MonoBehaviour
{
    //�o�^���ꂽ�\��̘a�����\��̃{�b�N�X���쐬
    public GameObject canvas;
    public GameObject prefab;
    void Start()
    {
        //�o�^���ꂽ�\��̐�����detail�v���n�u���쐬
        for (int i = 0; i < makeDataNumber.Listcount ; i++)
        {
            GameObject planbox = Instantiate(prefab, canvas.transform);
            planbox.GetComponent<DetailNumber>().detailnumber = makeDataNumber.PlanNumberList[i];
            Debug.Log("this Detail Number:"+planbox.GetComponent<DetailNumber>().detailnumber);
        }

///////////////////////////////////////////////////
       int ChildCount = this.transform.childCount;
       int j;
       int k;
       int mini=0;
        for(k=0;k<ChildCount;k++){
            DateTime mins = new DateTime(6000, 4, 15, 23, 59, 59, 999);
            DateTime minf = new DateTime(6000, 4, 16, 23, 59, 59, 999);
            for(j=0;j<ChildCount-k;j++){
                Data p = PlanList.DataList[transform.GetChild(j).gameObject.GetComponent<DetailNumber>().detailnumber];
                if(p.Start<mins){
                    mins = p.Start;
                    minf = p.Finish;
                    mini = j;
                }
            }
            transform.GetChild(mini).SetAsLastSibling();
        }

    }
}
