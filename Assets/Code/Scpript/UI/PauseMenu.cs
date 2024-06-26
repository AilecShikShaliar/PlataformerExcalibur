using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuPausa;

    private bool _pausedGame = false;

    public PlayerController _pCref;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pausedGame)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }

    }

    //metodos
    public void Pausa()
    {
        _pCref.enabled = false;
        Time.timeScale = 0f;
        MenuPausa.SetActive(true);
        _pausedGame = true;
    }

    public void Reanudar()
    {
        MenuPausa.SetActive(false);
        _pausedGame = false;
        _pCref.enabled = true;
        Time.timeScale = 1f;

    }

    public void Objetos()
    {
        Time.timeScale = 1f;
        MenuPausa.SetActive(false);
        _pausedGame = false;
    }

    public void Quit()
    {
        Debug.Log("adios");
        Application.Quit();
        AudioManager.audioReference.PlaySFX(3);
    }
}

