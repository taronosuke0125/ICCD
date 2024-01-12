using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class PlanList : MonoBehaviour
{
    public static Data[] DataList=new Data[99];//—\’è‚ÌƒŠƒXƒg
    public static int datacount;//—\’è‚ÌŒÂ”
   
    public void LoadPlan()
    {
        string datastr = "";
        StreamReader reader;
        //“Ç‚İæ‚èêŠ‚ğw’è
        reader = new StreamReader(Application.dataPath + "/savedata.json");
        datacount = 0;
        while (reader.Peek() != -1)
        {
            datastr = reader.ReadLine();//ˆês‚¸‚Â“Ç‚Ş
            DataList[datacount]=JsonConvert.DeserializeObject<Data>(datastr);//—\’è‚ğ—\’èƒŠƒXƒg‚É“o˜^
            datacount++;
        }
        reader.Close();
    }
    private void Start()
    {
        //Å‰‚Ésavedata‚ğ“Ç‚İ‚İƒŠƒXƒg‚ğì¬‚·‚é
        LoadPlan();
        int count = 0;
        while (DataList[count] != null)
        {
            DataList[count].view();
            DataList[count].IntToString();
            count++;
        }
        
    }
}
