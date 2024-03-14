using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelManager : MonoBehaviour
{
    private LSUIController  _lSUIReference;

    //REFERENCIA AL JUGADOR
    private PlayerControllerVal _PlayerController;

    // Start is called before the first frame update
    void Start()
    {
        //INICIALICIZAMOS SCRIPT JUGADOR
       

        //INICIALICIZAMOS SCRIPT LSUICONTROLLER
       _lSUIReference = GameObject.Find("LSCanvas").GetComponent<LSUIController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        //LLAMAMOS A LA CORRUTINA PARA CARGAR EL NIVEL
        StartCoroutine(LoadLevelCo());
    }

    public IEnumerator LoadLevelCo()
    {
        //FUNDIDO A NEGRO
        _lSUIReference.FadeToBlack();
        //ESPERAR TIEMPO DETERMINADO
        yield return new WaitForSeconds(1f);
        //CARAGAMOS EL NIVEL 
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            //SceneManager

        }
        
    }






}
