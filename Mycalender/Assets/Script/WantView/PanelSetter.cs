using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSetter : MonoBehaviour
{
    [SerializeField]
    GameObject Panel;
    void Start()
    {
        //�p�l���\���A��\���p�̃X�N���v�g��CoverPanel��o�^
        PanelActivator.Panel = Panel;     
    }

    
}
