using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FromSetPlan : MonoBehaviour
{
    public void SceneMove()
    {
        if (decidebutton.inedit)
        {//—\’è•ÒW
            InputPlantitle.DeleteNameStatic();
            decidebutton.inedit = false;
            SceneManager.LoadScene("detail");
        }
        else
        {//—\’è“o˜^
            InputPlantitle.DeleteNameStatic();
            SceneManager.LoadScene("Calender");
        }
    }
}
