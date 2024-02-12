using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class PlanPresetList:MonoBehaviour
{
    //予定プリセットのリストとその要素数
    public static PlanPreset[] morning = new PlanPreset[60];
    public static int morningcn;
    public static PlanPreset[] lunch = new PlanPreset[60];
    public static int lunchcn;
    public static PlanPreset[] dinner = new PlanPreset[60];
    public static int dinnercn;
    //予定プリセットが入ったテキストファイル
    public TextAsset morning_text;
    public TextAsset lunch_text;
    public TextAsset dinner_text;
    private static bool onceflag = true;
    private void Start()
    {
        //プログラム中一回だけ実行
        if (onceflag)
        {
            morningcn=LoadPreset(morning, morning_text);
            ViewPlan(morning);
            lunchcn = LoadPreset(lunch, lunch_text);
            ViewPlan(lunch);
            dinnercn = LoadPreset(dinner, dinner_text);
            ViewPlan(dinner);
            onceflag = false;
        }
        
    }
    //保存先の配列と元のテキストファイルを引数に指定し、追加した要素数を返すメソッド
    public static int LoadPreset(PlanPreset[] p, TextAsset dish_text)
    {
        string datastr = "";
        //読み取るテキストを指定
        StringReader reader = new StringReader(dish_text.text);
        
        int datacount = 0;
        
        while (reader.Peek() != -1)
        {
            datastr = reader.ReadLine();//一行ずつ読む
            datastr = "{" + datastr + "}";
            //一行目はタグなので保存しない
            if (datacount == 0)
            {
                datacount++;
                continue;
            }
            p[datacount-1] = JsonConvert.DeserializeObject<PlanPreset>(datastr);//予定プリセットを予定プリセットリストに登録
            datacount++;
        }
        p[datacount-1]=null;
        reader.Close();
        //配列の要素数を返す
        return datacount-1;
    }
    //渡された配列の要素をすべて出力する。
    public static void ViewPlan(PlanPreset[] p)
    {
        Debug.Log("veiw all preset");
        int i;
        for(i=0; p[i]!= null; i++)
        {
            p[i].view();
        }
    }
}