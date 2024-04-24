using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasilloChangeLevel : MonoBehaviour
{
    public int Scene;
     
    public GameObject infoPanel;

    public bool pasillo = false;


    private void Update()
    {
        if (pasillo == true)
            if (Input.GetKeyDown(KeyCode.F)) StartCoroutine(GameObject.Find("LevelManager").GetComponent<LevelManager>().ExitLevelCo(Scene));
              Debug.Log("pasarPasillo");
    }

       private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pasillo = true;
            infoPanel.SetActive(true);
        
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pasillo = false;
            infoPanel.SetActive(false);

        }
    }

}
