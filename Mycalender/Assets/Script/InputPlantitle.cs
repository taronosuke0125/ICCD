using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputPlantitle : MonoBehaviour
{
    public static TMP_InputField Name;
    public static string staticname;
    private void Start()
    {
        Name = GameObject.Find("InputPlanName").GetComponent<TMP_InputField>();
        Name.text = staticname;
    }
    //Inputbox‚Å•¶š‚ğ“ü—Í‚µ‚½‚çplanname‚É•Û‘¶
    public void EnteredPlanName()
    {
        staticname = Name.text;
        setstartday.planname = Name.text;
        Debug.Log(setstartday.planname);
    }
    //“o˜^‚µ‚½‚çstaticname‚ğ‰Šú‰»
    public static void DeleteNameStatic()
    {
        staticname = null;
    }
}
