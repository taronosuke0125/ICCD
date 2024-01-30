using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Automaker : MonoBehaviour
{
    [SerializeField] public Dropdown dropdown; 
     
    // Dataクラスの定義
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
        int index = dropdown.value;  // Dropdownの現在の値を取得
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
        // JSONファイルを読み込む
        string json = File.ReadAllText(path);

        // JSONデータをオブジェクトに変換
        Data[] dataArray = JsonUtility.FromJson<Data[]>(json);

        // 1から100の間でランダムなIDを生成
        int randomID = UnityEngine.Random.Range(1, 101);

        // ランダムなIDに対応する名前を取得
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
