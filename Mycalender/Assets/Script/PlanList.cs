using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class PlanList : MonoBehaviour
{
    public static Data[] DataList=new Data[99];//—\’è‚ÌƒŠƒXƒg
    public static int datacount;//—\’è‚ÌŒÂ”
    public static void LoadPlan()
    {
        string datastr = "";
        StreamReader reader;
        //“Ç‚İæ‚èêŠ‚ğw’è
        Debug.Log(Application.persistentDataPath);
        reader = new StreamReader(Application.persistentDataPath + "/savedata.json");
        datacount = 0;
        while (reader.Peek() != -1)
        {
            datastr = reader.ReadLine();//ˆês‚¸‚Â“Ç‚Ş
            DataList[datacount]=JsonConvert.DeserializeObject<Data>(datastr);//—\’è‚ğ—\’èƒŠƒXƒg‚É“o˜^
            DataList[datacount].IntToString();
            datacount++;
        }
        reader.Close();
    }

    public static void viewPlan()
    {
        int i;
        Debug.Log("datacount:"+datacount);
        for (i = 0; i < datacount; i++)
            DataList[i].view();
    }


    private void Start()
    {
        //Å‰‚Ésavedata‚ğ“Ç‚İ‚İƒŠƒXƒg‚ğì¬‚·‚é
        LoadPlan();
        viewPlan();
    }
}
