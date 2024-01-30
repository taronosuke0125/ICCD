using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Timetext : MonoBehaviour
{
    public static string starttime="00:00";//Timeset.cs‚Å“ü—Í‚³‚ê‚½ŽžŠÔ‚ðŠi”[
    public static string finishtime="00:00";//Timeset.cs‚Å“ü—Í‚³‚ê‚½ŽžŠÔ‚ðŠi”[
    // Start is called before the first frame update
    void Start()
    {
        regist_time();
    }
    //“n‚³‚ê‚½ŽžŠÔ‚ð“o˜^‰æ–Ê‚É•\Ž¦‚·‚é
    public static void regist_time()
    {
        GameObject.Find("StartTime").GetComponent<TextMeshProUGUI>().text = starttime;
        GameObject.Find("FinishTime").GetComponent<TextMeshProUGUI>().text = finishtime;
    }
}
