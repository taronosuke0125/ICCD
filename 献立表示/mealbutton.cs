using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mealbutton : MonoBehaviour
{
    // Start is called before the first frame update
    public void mealbuttonB(){
        int i = Random.Range(0, 9);
        string howmake = mealinit.meal[i];
        Debug.Log(howmake);
        GameObject.Find("InputField").GetComponent<Memoedit>().inputField.text = howmake;
    }
}
