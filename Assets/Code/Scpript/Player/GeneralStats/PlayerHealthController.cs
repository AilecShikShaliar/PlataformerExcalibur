using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maximoVida;

    [SerializeField] private LifeBar _lifeBar;

    // Start is called before the first frame update
    void Start()
    {
        vida = maximoVida;

        _lifeBar =  GameObject.Find("life").GetComponent<LifeBar>();

    }

   public void Daño(float daño)
   {
     vida -= daño;
     _lifeBar.CambiarVidaActual(vida);
     if (vida <= 0) Destroy(gameObject);
   }


}
