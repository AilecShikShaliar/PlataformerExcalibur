using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Puerta : MonoBehaviour
{
    #region VARIABLES Y REFERENCIAS

    private SpriteRenderer _sR;

    private bool _isopen = true;

    private bool _canopendoor = false;

    public Animator puertaanim;


    private LevelManager _lReference;
    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        
        _lReference = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        puertaanim = GetComponent<Animator>();

        _sR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _canopendoor == true) 

        {
            puertaanim.SetTrigger("openDoor");
            
            _lReference.ExitLevel();
            
        }
    }
    #endregion

    #region MY METHODS
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _canopendoor = true;
        
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _canopendoor = false;
        }
    }

    #endregion
}
