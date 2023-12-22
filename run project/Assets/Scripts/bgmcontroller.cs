using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmcontroller : MonoBehaviour
{
    AudioSource audioSource;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = this.GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GameOver){
            audioSource.Stop();
            }   
    }
}
