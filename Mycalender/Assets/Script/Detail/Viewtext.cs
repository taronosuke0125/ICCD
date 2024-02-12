using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//追加する！
using UnityEngine.UI;
using TMPro;
public class Viewtext : MonoBehaviour {

  //オブジェクトと結びつける
  public InputField inputField;
  public TextMeshProUGUI text;

  void Start () {
    //Componentを扱えるようにする
        inputField = inputField.GetComponent<InputField> ();
        text = text.GetComponent<TextMeshProUGUI> ();
        Data p = PlanList.DataList[transform.parent.parent.parent.gameObject.GetComponent<DetailNumber>().detailnumber];
        Debug.Log(p.memo);
        inputField.text = p.memo;
        //Debug.Log(p.memo);
        //text.text = p.memo;
        //text.text = Genelist.stext;
    }

    public void InputText(){
                //テキストにinputFieldの内容を反映
        text.text = inputField.text;
        Data p = PlanList.DataList[transform.parent.parent.parent.gameObject.GetComponent<DetailNumber>().detailnumber];
        p.memo = text.text;
        //Debug.Log(p.memo);
     }

}