using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSetter : MonoBehaviour
{
    [SerializeField]
    GameObject Panel;
    void Start()
    {
        //パネル表示、非表示用のスクリプトにCoverPanelを登録
        PanelActivator.Panel = Panel;     
    }

    
}
