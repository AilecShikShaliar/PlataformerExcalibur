using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyonSwihct : MonoBehaviour
{
    [SerializeField] GameObject KillZone;

    public bool desactivar = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (desactivar == true) 
        {
            KillZone.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Jaimito"))
         {
            desactivar = true;
        }

    }
}
