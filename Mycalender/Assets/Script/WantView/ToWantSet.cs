using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToWantSet : MonoBehaviour
{
    //WantSetシーンへ遷移
    public void ToWantSetScene()
    {
        SceneManager.LoadScene("WantSet");
    }
}
