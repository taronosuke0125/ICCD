using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clearsound : MonoBehaviour
{
    AudioSource audioSource;
    private GameManager gameManager;
    bool clearonce = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = this.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GameOver){
            if(!clearonce){
            audioSource.Play();
            clearonce=true;
            }
        }   
    }
}
