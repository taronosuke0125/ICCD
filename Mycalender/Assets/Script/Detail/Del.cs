using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Del : MonoBehaviour
{
    //ボタンを押したときに呼び出す(1/14更新)
    public void Pushdel(){
       DeletePlan();
        Debug.Log("pushdel");
    } 
    //予定を削除
    public void DeletePlan()
    {
        GameObject parent = transform.parent.gameObject;
        int number = parent.GetComponent<DetailNumber>().detailnumber;
        DeleteLine(number,0);
        PlanList.LoadPlan();
        PlanList.viewPlan();
        //現在のシーンをリロード
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //やりたいことを削除
    public void DeleteWantPlan()
    {
        GameObject parent = transform.parent.parent.gameObject;
        int number = parent.GetComponent<WantDetailNumber>().wantdetailnumber;
        DeleteLine(number, 1);
        WantPlanList.LoadWantPlan();
        WantPlanList.viewWantPlan();
        //現在のシーンをリロード
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //jsonファイルのn行目を削除(n=0,1,2,3....),m=0のとき予定を削除,m=1のときやりたいことを削除
    public void DeleteLine(int n,int m)
    {
        int count = 0;
        //ファイルのパス
        string filePath;
        if (m == 0)
           filePath = Application.persistentDataPath + "/savedata.json";//予定
        else
           filePath = Application.persistentDataPath + "/savewantdata.json";//やりたいこと
        //ファイルを読み込みで開く
        System.IO.StreamReader sr = new System.IO.StreamReader(filePath);
        //一時ファイルを作成する
        string tmpPath = System.IO.Path.GetTempFileName();
        //一時ファイルを書き込みで開く
        System.IO.StreamWriter sw = new System.IO.StreamWriter(tmpPath);

        //内容を一行ずつ読み込む
        while (sr.Peek() > -1)
        {
            //一行読み込む
            string line = sr.ReadLine();
            //指定した行であれば、飛ばす
            if (count == n)
            {
                count++;
                continue;
            }
            //一時ファイルに書き込む
            sw.WriteLine(line);
            count++;
        }
        //閉じる
        sr.Close();
        sw.Close();

        //一時ファイルと入れ替える
        System.IO.File.Copy(tmpPath, filePath, true);
        System.IO.File.Delete(tmpPath);
    }
}
