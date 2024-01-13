using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Del : MonoBehaviour
{
    
    public void Pushdel(){
        GameObject parent = transform.parent.gameObject;
        Destroy(parent);
    } 
}
