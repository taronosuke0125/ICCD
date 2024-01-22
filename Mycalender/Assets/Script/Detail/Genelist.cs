using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.Transform;

public class Genelist : MonoBehaviour
{
     private const string PASSWORD_CHARS = 
        "0123456789abcdefghijklmnopqrstuvwxyz";

    public bool open = false;
    [SerializeField]
    public GameObject obj;//詳細パネルオブジェクト
    
    public bool a = true;
   
    public string rnd;

    public void BGenelist(){ 
        Transform tri = transform.Find("triangle2");
        
        if(open){        
            tri.Rotate(180,0,0);    
            //GameObject child = transform.GetChild(0).gameObject;
            Transform dest = transform.root.Find("gamen").Find(rnd);

            Debug.Log(rnd);

            Destroy(dest.gameObject);
            open = false;
        }else{
            tri.Rotate(180,0,0); 
            open=true;

            rnd = GeneratePassword(10);

            Debug.Log(rnd);

            Transform root = transform.root.Find("gamen");

            GameObject obj2 = Instantiate (obj,root);
            obj2.name=rnd;
            

            //次の順番にオブジェクトに配置
            int sibindex = transform.parent.GetSiblingIndex();            
            obj2.transform.SetSiblingIndex(sibindex+1);

            Transform t = obj2.transform;
            Vector3 pos=t.position;
            pos.x-=0.2f;
            pos.y-=4.3f;
            t.position =pos;
        }
    }

    public static string GeneratePassword( int length )
    {
        var sb  = new System.Text.StringBuilder( length );
        var r   = new System.Random();

        for ( int i = 0; i < length; i++ )
        {
            int     pos = r.Next( PASSWORD_CHARS.Length );
            char    c   = PASSWORD_CHARS[ pos ];
            sb.Append( c );
        }

        return sb.ToString();
    }
}
