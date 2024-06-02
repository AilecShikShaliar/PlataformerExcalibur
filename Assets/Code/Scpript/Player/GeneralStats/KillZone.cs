using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKill : MonoBehaviour
{

    private PlayerHealth _pHReference;
    private LifeBar _lifebar;
    private GameOverMenu _gOMenu;

    // Start is called before the first frame update

    private void Awake()
    {
        _gOMenu = GameObject.Find("LevelManager").GetComponent<GameOverMenu>();
    }
    void Start()
    {
        _pHReference = GameObject.Find("Player").GetComponent<PlayerHealth>();
        _lifebar = GameObject.Find("Canvas").GetComponent<LifeBar>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _pHReference.currentHealth = 0;
            _lifebar.ActualizarVida();
            _gOMenu.GameOver();
        }
    }
}