using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromWantSet : MonoBehaviour
{
    //やりたいこと登録(編集)シーンからやりたいこと一覧シーンへ遷移
    public void SceneMove()
    {
        InputWantPlanTitle.DeleteNameStatic();
        decidebutton.inedit = false;
        SceneManager.LoadScene("WantView");
    }
}
