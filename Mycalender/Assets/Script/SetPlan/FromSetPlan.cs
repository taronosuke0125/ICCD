using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FromSetPlan : MonoBehaviour
{
    public void SceneMove()
    {
        if (decidebutton.inedit)
        {//�\��ҏW��
            InputPlantitle.DeleteNameStatic();
            decidebutton.inedit = false;
            SceneManager.LoadScene("detail");
        }
        else
        {//�\��o�^��
            InputPlantitle.DeleteNameStatic();
            SceneManager.LoadScene("Calender");
        }
    }
}
