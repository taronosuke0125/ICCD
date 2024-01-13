using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.Transform;

public class Genelist : MonoBehaviour
{
    public static bool open = false;
    [SerializeField]
    public GameObject obj;//詳細パネルオブジェクト
    public void BGenelist(){ 
        Transform tri = transform.Find("triangle2");
        
        if(open){        
            tri.Rotate(180,0,0);    
            //GameObject child = transform.GetChild(0).gameObject;
            GameObject child = transform.Find("View(Clone)").gameObject;
            Destroy(child);
            open = false;
        }else{
            tri.Rotate(180,0,0); 
            open=true;
            var parent = this.transform;
            //GameObject parent = transform.parent.gameObject;

            //プレハブを元に、インスタンスを生成、
            //Instantiate (obj, Quaternion.identity);
            //Instantiate (obj, new Vector3(0,0,0), Quaternion.identity,parent);
            GameObject obj2 = Instantiate (obj,parent);
            Transform t = obj2.transform;
            Vector3 pos=t.position;
            pos.x-=0.2f;
            pos.y-=4.3f;
            t.position =pos;
        }
    }
}
