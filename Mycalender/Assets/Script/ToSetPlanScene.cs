using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSetPlanScene : MonoBehaviour
{
    public void OnClickAddButton()
    {
        SceneManager.LoadScene("SetPlan");
    }
}
