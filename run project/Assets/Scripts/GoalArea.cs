using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalArea : MonoBehaviour
{
    private GameManager gameManager;
    private bool gameClear;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other){
        if(!gameClear && other.CompareTag("Player")){
            gameClear = true;
            gameManager.ClearGame();
        }
    }
}
