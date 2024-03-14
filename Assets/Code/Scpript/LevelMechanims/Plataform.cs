using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    Collider2D _plataformCollider;

    private bool _PlataformOn;
    // Start is called before the first frame update
    void Start()
    {
        _plataformCollider = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") < -0.5f && _PlataformOn)
        {
            //DESACTIVAR COMPONENTE COLLAIDER
            _plataformCollider.enabled = false; // enabled = desactivar componentes de los objetos 
            StartCoroutine(ActDeactPlataformCo());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _PlataformOn = false; 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _PlataformOn = true;
        }
    }

    private IEnumerator ActDeactPlataformCo()
    {
        _plataformCollider.enabled = false;
        yield return new WaitForSeconds(.5f);
        _plataformCollider.enabled = true;


    }
}
