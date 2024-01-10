using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class PlanList : MonoBehaviour
{
    public static Data[] DataList=new Data[99];
    public static int datacount = 0;
    public void setData(Data data)
    {
        DataList[datacount] = data;
        datacount++;
    }
    public void LoadPlan()
    {
        string datastr = "";
        StreamReader reader;
        //“Ç‚İæ‚èêŠ‚ğw’è
        reader = new StreamReader(Application.dataPath + "/savedata.json");
        while (reader.Peek() != -1)
        {
            datastr = reader.ReadLine();//ˆês‚¸‚Â“Ç‚Ş
             setData(JsonConvert.DeserializeObject<Data>(datastr));//—\’è‚ğ—\’èƒŠƒXƒg‚É“o˜^
        }
        reader.Close();
    }
    private void Start()
    {
        LoadPlan();
        int count = 0;
        while (DataList[count] != null)
        {
            DataList[count].view();
            count++;
        }
        Debug.Log(datacount);
    }
}
