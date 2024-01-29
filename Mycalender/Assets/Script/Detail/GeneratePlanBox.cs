using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlanBox : MonoBehaviour
{
    //“o˜^‚³‚ê‚½—\’è‚Ì”‚¾‚¯—\’è‚Ìƒ{ƒbƒNƒX‚ğì¬
    public GameObject canvas;
    public GameObject prefab;
    void Start()
    {
        //“o˜^‚³‚ê‚½—\’è‚Ì”‚¾‚¯detailƒvƒŒƒnƒu‚ğì¬
        for (int i = 0; i < makeDataNumber.Listcount ; i++)
        {
            GameObject planbox = Instantiate(prefab, canvas.transform);
            planbox.GetComponent<DetailNumber>().detailnumber = makeDataNumber.PlanNumberList[i];
            Debug.Log("this Detail Number:"+planbox.GetComponent<DetailNumber>().detailnumber);
        }
    }
}
