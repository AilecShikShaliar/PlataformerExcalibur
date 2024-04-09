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

    public GameObject infoPanel;

    public int levelToLoad;

    private PuertaMenu _puertaM;
    
    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        
        _lReference = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        _puertaM = GameObject.Find("LevelManager").GetComponent<PuertaMenu>();

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
            _puertaM.Pausa();
            
            
        }
    }
    #endregion

    #region MY METHODS
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _canopendoor = true;
            infoPanel.SetActive(true);
        
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _canopendoor = false;
            infoPanel.SetActive(false);

        }
    }

    public void LoadLevel(int n)
    {
        StartCoroutine(_lReference.ExitLevelCo(n));
    }

    #endregion
}
