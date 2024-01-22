using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = (GameObject)Resources.Load ("Panel");
        var parent = this.transform;
        Instantiate (obj, new Vector3(0,0,0), Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
