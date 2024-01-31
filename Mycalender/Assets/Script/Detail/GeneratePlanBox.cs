using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlanBox : MonoBehaviour
{
    //�o�^���ꂽ�\��̐������\��̃{�b�N�X���쐬
    public GameObject canvas;
    public GameObject prefab;
    public GameObject cancelbotton;
    void Start()
    {
        //�o�^���ꂽ�\��̐�����detail�v���n�u���쐬
        for (int i = 0; i < makeDataNumber.Listcount ; i++)
        {
            GameObject planbox = Instantiate(prefab, canvas.transform);
            planbox.GetComponent<DetailNumber>().detailnumber = makeDataNumber.PlanNumberList[i];
            Debug.Log("this Detail Number:"+planbox.GetComponent<DetailNumber>().detailnumber);
        }
        GameObject cancel = Instantiate(cancelbotton,canvas.transform);
    }
}
