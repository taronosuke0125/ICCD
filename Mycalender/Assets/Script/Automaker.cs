using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Automaker : MonoBehaviour
{
    [SerializeField] public Dropdown dropdown; 
     
    // Data�N���X�̒�`
    [System.Serializable]
    public class Data
    {
        public int ID;
        public string Name;
    }
    // Start is called before the first frame update
    public void MakeAuto()
    {
        if (dropdown == null)
        {
            Debug.LogError("Dropdown is not set");
            return;
        }
        int index = dropdown.value;  // Dropdown�̌��݂̒l���擾
        string jsonfile ="";
        switch (index)
        {
            case 0:
                jsonfile = "morning.json";
                break;
            case 1:
                jsonfile = "lunch.json";
                break;
            case 2:
                jsonfile = "dinner.json";
                break;
        }
        string path = Path.Combine(Application.dataPath, jsonfile);
        // JSON�t�@�C����ǂݍ���
        string json = File.ReadAllText(path);

        // JSON�f�[�^���I�u�W�F�N�g�ɕϊ�
        Data[] dataArray = JsonUtility.FromJson<Data[]>(json);

        // 1����100�̊ԂŃ����_����ID�𐶐�
        int randomID = UnityEngine.Random.Range(1, 101);

        // �����_����ID�ɑΉ����閼�O���擾
        foreach (Data data in dataArray)
        {
            if (data.ID == randomID)
            {
                Debug.Log("Name of the random ID: " + data.Name);
                break;
            }
        }
    }
}
