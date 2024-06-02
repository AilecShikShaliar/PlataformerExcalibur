using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicDialogue : MonoBehaviour
{
    public State stateNew;
    private Game _gameState;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider)
    {
        _gameState = GameObject.Find("Canvas").GetComponent<Game>();
        _gameState.paneldialog.SetActive(true);
        CallLoadState();
        FindObjectOfType<PlayerController>().canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void CallLoadState()
    {
        GameObject.Find("Canvas").GetComponent<Game>().LoadState(stateNew);
    }

  
    
}
