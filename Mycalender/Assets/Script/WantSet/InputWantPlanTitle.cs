using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputWantPlanTitle : MonoBehaviour
{
    public static TMP_InputField Name;
    public static string staticname;
    private void Start()
    {
        Name = GameObject.Find("InputWantPlanName").GetComponent<TMP_InputField>();
        Name.text = staticname;
    }
    //Inputbox‚Å•¶š‚ğ“ü—Í‚µ‚½‚çwantplanname‚É•Û‘¶
    public void EnteredWantPlanName()
    {
        staticname = Name.text;
        //setstartday.planname = Name.text;
        Debug.Log(staticname);
    }
    //“o˜^‚µ‚½‚çstaticname‚ğ‰Šú‰»
    public static void DeleteNameStatic()
    {
        staticname = null;
    }
}
