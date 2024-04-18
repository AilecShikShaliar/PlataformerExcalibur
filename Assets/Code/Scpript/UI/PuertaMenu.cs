using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaMenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuPuerta;

    private bool _pausedGame = false;
    public PlayerControllerVal _pCref;
    private Puerta _puertaYhea;
    private PauseMenu _MenuP;
    //private PuertaCursor _pCursor;
    

    private void Awake()
    {
        _MenuP = GetComponent<PauseMenu>();
        //_pCursor = GameObject.Find("PuertaPausa").GetComponent<PuertaCursor>();

    }


    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (_pausedGame)
            {
                Reanudar();
                AudioManager.audioReference.PlaySFX(2);
              

            }
        }


    }

    //metodos
    public void Pausa()
    {
        _pCref.enabled = false;
        Time.timeScale = 0f;
        MenuPuerta.SetActive(true);
        _pausedGame = true;
        _MenuP.enabled = true;
        //_pCursor.enabled = false;
       


    }

    public void Reanudar()
    {
        MenuPuerta.SetActive(false);
        _pausedGame = false;
        _pCref.enabled = true;
        Time.timeScale = 1f;
        _MenuP.enabled = false;
        //_pCursor.enabled = true;

    }

   

}

