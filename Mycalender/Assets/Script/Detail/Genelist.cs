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

    public string stext;

    public void BGenelist(){ 
        Transform tri = transform.Find("triangle2");
        
        if(open){        
            tri.Rotate(180,0,0);    
            //GameObject child = transform.GetChild(0).gameObject;
            Transform dest = transform.root.Find("gamen").Find(rnd);
            string s = dest.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Viewtext>().inputField.text;
            int n = transform.parent.gameObject.GetComponent<DetailNumber>().detailnumber;

            Editonlyer(n, s);
            Destroy(dest.gameObject);
            open = false;
        }else{
            tri.Rotate(180,0,0); 
            open=true;

            rnd = GeneratePassword(10);

            //Debug.Log(rnd);

            Transform root = transform.root.Find("gamen");

            GameObject obj2 = Instantiate (obj,root);
            obj2.name=rnd;
            obj2.GetComponent<DetailNumber>().detailnumber = transform.parent.gameObject.GetComponent<DetailNumber>().detailnumber;
            

            //次の順番にオブジェクトに配置
            int sibindex = transform.parent.GetSiblingIndex();            
            obj2.transform.SetSiblingIndex(sibindex+1);

            Transform t = obj2.transform;
            Vector3 pos=t.position;
            pos.x-=0.2f;
            pos.y-=100f;
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

    //編集画面でmemoに記述するとjsonファイルや配列にその結果を反映
    public void Editonlyer(int n, string s)
    {

        Data schedule = PlanList.DataList[n];

        schedule.memo = s;

        string jsonschedule = JsonUtility.ToJson(schedule);
        int count = 0;
        // t @ C   ̃p X
        string filePath = Application.persistentDataPath + "/savedata.json";
        // t @ C    ǂݍ  ݂ŊJ  
        System.IO.StreamReader sr = new System.IO.StreamReader(filePath);
        // ꎞ t @ C     쐬    
        string tmpPath = System.IO.Path.GetTempFileName();
        // ꎞ t @ C           ݂ŊJ  
        System.IO.StreamWriter sw = new System.IO.StreamWriter(tmpPath);

        //   e    s   ǂݍ   
        while (sr.Peek() > -1)
        {
            //  s ǂݍ   
            string line = sr.ReadLine();
            // w 肵   s ł   ΁A ҏW     \    i [    
            if (count == n)
            {
                line = jsonschedule;
            }
            // ꎞ t @ C   ɏ       
            sw.WriteLine(line);
            count++;
        }
        //    
        sr.Close();
        sw.Close();

        // ꎞ t @ C   Ɠ   ւ   
        System.IO.File.Copy(tmpPath, filePath, true);
        System.IO.File.Delete(tmpPath);
        // \   o ^     玞 Ԃ       

    }
}
