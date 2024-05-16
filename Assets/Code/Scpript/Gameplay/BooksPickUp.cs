using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooksPickUp : MonoBehaviour
{
    public bool isBook;
    private bool _isCollected;
    private bool _canCollect = false;
    private UIController _uIReference;
    private LevelManager _lMReference;
    public bool _ihaveBookyhea;
    public bool canInteract;
    public KeyManager keym;
    // Start is called before the first frame update
    void Start()
    {
        _lMReference = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        _uIReference = GameObject.Find("Canvas").GetComponent<UIController>();
        canInteract = false;
        if (GameObject.Find("KeyManager")) keym = GameObject.Find("KeyManager").GetComponent<KeyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.F))
        {
            _lMReference.RecogerLibro(); Destroy(gameObject);
            if (keym != null)
            {
                keym.UptadeKeyState();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player") && !_isCollected)
        {
            print("toco el libro");
            _canCollect = true;
            canInteract = true;
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;
    }
}
