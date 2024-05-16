using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
   
{
    [SerializeField]public float currentHealth;
    public const float MAXHP = 100.0f;
    private Slider slider;
    private LevelManager _lMReference;
    public bool playerDead = false;
    //private GameOverMenu _gOMenu;
    private PlayerController _pCReference;

    private void Start()
    {
        slider = GetComponent<Slider>();
        
    }

    private void Update()
    {
        slider.value = currentHealth / MAXHP*100;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            _lMReference.RespawnPlayer();
            //_gOMenu.GameOver();
            playerDead = true;
            _pCReference.gameObject.SetActive(false);
        }
    }
    public void SumarVida(float cantidadVida)
    {
        currentHealth += cantidadVida;
    }

    public void RestarVida(float cantidadVida)
    {
        currentHealth -= cantidadVida;
    }

    public void InicializarBarraDeVida (float cantidadVida)
    {
        currentHealth = cantidadVida;
    }
}
