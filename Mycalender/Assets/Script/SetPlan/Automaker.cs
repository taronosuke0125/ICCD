using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Automaker : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] TMP_InputField InputField;
    //自動作成ボタンに
    public void MakeAuto()
    {
        if (dropdown == null)
        {
            Debug.LogError("Dropdown is not set");
            return;
        }
        int index = dropdown.value;  // Dropdownの現在の値を取得
        int imax;//プリセットの要素数
        PlanPreset[] plist;//プリセットの配列
        //indexの値によって朝、昼、夜どの献立を呼び出すか指定
        switch (index)
        {
            case 0:
                imax = PlanPresetList.morningcn;
                plist = PlanPresetList.morning;
                break;
            case 1:
                imax = PlanPresetList.lunchcn;
                plist = PlanPresetList.lunch;
                break;
            case 2:
                imax = PlanPresetList.dinnercn;
                plist = PlanPresetList.dinner;
                break;
            default:
                imax = 0;
                plist = null;
                break;
        }
        // 1から100の間でランダムなIDを生成
        int randomID = UnityEngine.Random.Range(1, imax);

        // ランダムなIDに対応する名前を取得
        foreach (PlanPreset p in plist)
        {
            if (p.ID==randomID)
            {
                InputField.text = p.name;
                InputField.GetComponent<InputPlantitle>().EnteredPlanName();
                break;
            }
        }
    }
}
