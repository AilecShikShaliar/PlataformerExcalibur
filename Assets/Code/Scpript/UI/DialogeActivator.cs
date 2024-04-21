using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    //L�neas del di�logo
    public string[] lines;
    //Para saber si el di�logo se puede activar o no
    private bool canActivate;
    //Sprite de di�logo del NPC
    public Sprite theNpcSprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Si el jugador puede activar el di�logo y presiona el bot�n de interacci�n y la caja de di�logo no est� activa en la jerarqu�a
        if (canActivate && Input.GetKeyDown(KeyCode.F) && !DialogueManager.instance.dialogBox.activeInHierarchy)
        {

            DialogueManager.instance.ShowDialog(lines, theNpcSprite);
            GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        }
    }

    //Si el jugador entra en la zona de Trigger puede activar el di�logo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            canActivate = true;

    }

    //Si el jugador sale de la zona de Trigger ya no puede activar le di�logo
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            canActivate = false;
    }
}