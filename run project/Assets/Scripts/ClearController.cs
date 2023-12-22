using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearController : MonoBehaviour
{
    public GameObject ClearText;
    // Start is called before the first frame update
    void Start()
    {
        ClearText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            ClearText.SetActive(true);
        }
    }
}
