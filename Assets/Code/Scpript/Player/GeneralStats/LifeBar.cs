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
        _lMReference = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        if (PlayerPrefs.HasKey("life"))
            currentHealth = PlayerPrefs.GetFloat("life");

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
           
        }
    }
    public void SumarVida(float cantidadVida)
    {
        currentHealth += cantidadVida;
        ActualizarVida();
    }

    public void RestarVida(float cantidadVida)
    {
        currentHealth -= cantidadVida;
        ActualizarVida();
    }

    public void InicializarBarraDeVida (float cantidadVida)
    {
        currentHealth = cantidadVida;
        ActualizarVida();
    }

    public void ActualizarVida()
    {
       
        PlayerPrefs.SetFloat("life", currentHealth);
    }
}
