using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObj : MonoBehaviour
{

    public bool isKey;
    private bool _isCollected;
    private LevelManager _lMReference;
    //Referencian al UIController
    private UIController _uIReference;
    private bool _canCollect = false;
    private BooksPickUp _BPU;
    private void Start()
    {
        //Inicializamos la referencia al UIController
        _uIReference = GameObject.Find("Canvas").GetComponent<UIController>();
        //Inicializamos la referencia al PlayerHealthController
        //_pHReference = GameObject.Find("Player").GetComponent<PlayerHealthController>();
        _lMReference = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        
    }

    void Update()
    {
        if (_canCollect && Input.GetKeyDown(KeyCode.F))
        {
            _lMReference.keycollected++;
            Destroy(gameObject);
         
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !_isCollected)
        {
            print("toco el llave");
            _canCollect = true;
            

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !_isCollected)
        {
            print("toco el llave");
            _canCollect = false;


        }
    }
}