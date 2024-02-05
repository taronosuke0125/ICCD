using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Automaker : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] TMP_InputField InputField;
    //�����쐬�{�^����
    public void MakeAuto()
    {
        if (dropdown == null)
        {
            Debug.LogError("Dropdown is not set");
            return;
        }
        int index = dropdown.value;  // Dropdown�̌��݂̒l���擾
        int imax;//�v���Z�b�g�̗v�f��
        PlanPreset[] plist;//�v���Z�b�g�̔z��
        //index�̒l�ɂ���Ē��A���A��ǂ̌������Ăяo�����w��
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
        // 1����100�̊ԂŃ����_����ID�𐶐�
        int randomID = UnityEngine.Random.Range(1, imax);

        // �����_����ID�ɑΉ����閼�O���擾
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
