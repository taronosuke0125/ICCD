using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToWantView : MonoBehaviour
{
   //wantボタンを押すとカレンダーシーンからやりたいことリスト画面に遷移
   public void ToWantViewScene()
    {
        SceneManager.LoadScene("WantView");
    }
}
