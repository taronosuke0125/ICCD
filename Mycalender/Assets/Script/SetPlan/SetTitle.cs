using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SetTitle : MonoBehaviour
{
    //���t�擾�p
    public static DateTime SelectDate;
    
    //��{�I�ɑ��̃��\�b�h�ɌĂяo�����`�Ŏg�p����B
    public void TitleController(DateTime SelectDate)
    {
        this.transform.GetChild(0).GetComponent<Text>().text = SelectDate.ToString("yyyy/MM/dd");
    }
    // Start is called before the first frame update
    
}
