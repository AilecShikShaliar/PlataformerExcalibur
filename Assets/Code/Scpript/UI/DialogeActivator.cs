using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    //Líneas del diálogo
    public State stateNew;
    //Para saber si el diálogo se puede activar o no
    private bool canActivate;
    private Game _gameState;
    

    // Start is called before the first frame update
    void Start()
    {
        _gameState = GameObject.Find("Canvas").GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si el jugador puede activar el diálogo y presiona el botón de interacción y la caja de diálogo no está activa en la jerarquía
        //if (canActivate && Input.GetKeyDown(KeyCode.F) && !DialogueManager.instance.dialogBox.activeInHierarchy)
        //{

        //    DialogueManager.instance.ShowDialog(lines, theNpcSprite);
        //    FindObjectOfType<PlayerController>().canMove = false;
        //}
        if (canActivate && Input.GetKeyDown(KeyCode.F))
        {
            _gameState.paneldialog.SetActive(true);
            CallLoadState();
            FindObjectOfType<PlayerController>().canMove = false;
        }
        

    }

    //Si el jugador entra en la zona de Trigger puede activar el diálogo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            canActivate = true;

    }

    //Si el jugador sale de la zona de Trigger ya no puede activar le diálogo
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            canActivate = false;
    }

    public void CallLoadState()
    {
        GameObject.Find("Canvas").GetComponent<Game>().LoadState(stateNew);
    }

    
}
