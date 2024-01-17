using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Updater : MonoBehaviour
{
    // Start is called before the first frame update    
    public Text Nametext;
    public Text Timetext;

    // Update is called once per frame
    void Update()
    {
        string pname;
        int so,sm,fo,fm;
        so=13;
        sm=30;
        fo=14;
        fm=0;

        pname = "夕ご飯";

        Nametext.text = pname;
        Timetext.text = zerostring(so) + ":" + zerostring(sm) + "～" + zerostring(fo) + ":" + zerostring(fm); 
    }

    //0や1を00、01にする。
    public string zerostring(int a){
        string b;
        if(a<=9){
            b = "0" + a.ToString();
        }else{
            b = a.ToString();
        }
        return b;
    } 
}
