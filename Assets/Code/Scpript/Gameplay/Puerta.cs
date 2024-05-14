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

   public int LevelToLoad;

    private PuertaMenu _puertaM;

    private PlayerController _PCRef;

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
        if (FindObjectOfType<PlayerController>()) _PCRef = FindObjectOfType<PlayerController>();
        _sR = GetComponent<SpriteRenderer>();


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _canopendoor == true) 

        {
            puertaanim.SetTrigger("openDoor");
            _puertaM.Pausa();
            AudioManager.audioReference.PlaySFX(2);
           // _PCRef.enabled = false;
            
            
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
        _PCRef.enabled = true;
        StartCoroutine(_lReference.ExitLevelCo(n));
        
    }

    #endregion
}
