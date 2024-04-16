using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasilloChangeLevel : MonoBehaviour
{
    public int Scene;
     
    public GameObject infoPanel;
    


    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.CompareTag ("Player"))
        {

           if(Input.GetKeyDown(KeyCode.Return)) StartCoroutine(GameObject.Find("LevelManager").GetComponent<LevelManager>().ExitLevelCo(Scene));
            Debug.Log("pasarPasillo");
        }
    }

       private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            infoPanel.SetActive(true);
        
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            infoPanel.SetActive(false);

        }
    }

}
