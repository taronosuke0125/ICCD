using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromWantSet : MonoBehaviour
{
    //��肽�����Ɠo�^(�ҏW)�V�[�������肽�����ƈꗗ�V�[���֑J��
    public void SceneMove()
    {
        InputWantPlanTitle.DeleteNameStatic();
        decidebutton.inedit = false;
        SceneManager.LoadScene("WantView");
    }
}
