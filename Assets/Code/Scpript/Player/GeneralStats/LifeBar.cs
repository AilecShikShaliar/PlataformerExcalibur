using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
   
{
    [SerializeField]public float currentHealth;
    public const float MAXHP = 100.0f;
    private Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
        
    }

    private void Update()
    {
        slider.value = currentHealth / MAXHP*100;
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
