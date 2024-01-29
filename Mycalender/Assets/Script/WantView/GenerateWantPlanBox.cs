using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateWantPlanBox : MonoBehaviour
{
    public GameObject canvas;
    public GameObject prefab;
    //�o�^���ꂽ��肽�����Ƃ̐�������肽�����Ƃ̃{�b�N�X���쐬�B
    public void Start()
    {
        //�o�^���ꂽ��肽�����Ƃ̐�����WantPlanPanel�v���n�u���쐬
        for (int i = 0; i < WantPlanList.wantdatacount; i++)
        {
            GameObject planbox = Instantiate(prefab, canvas.transform);
            planbox.GetComponent<WantDetailNumber>().wantdetailnumber = i;
            planbox.transform.GetChild(1).GetComponent<Text>().text = WantPlanList.WantDataList[i].Name;
            Debug.Log("this Detail Number:" + planbox.GetComponent<WantDetailNumber>().wantdetailnumber);
        }
    }
}
