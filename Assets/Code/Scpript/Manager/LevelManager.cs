using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Variable de tiempo para la corrutina
    public float waitToRespawn;

    //Refs
    private PlayerControllerVal _pCReference;
    private CheckpointController _cReference;
    //private UIController _uIReference;
    private PlayerHealthController _pHReference;

    private void Start()
    {
        //Inicializamos las refs
        _pCReference = GameObject.Find("Player").GetComponent<PlayerControllerVal>();
        _cReference = GameObject.Find("CheckPointController").GetComponent<CheckpointController>();
        //_uIReference = GameObject.Find("Canvas").GetComponent<UIController>();
        //_pHReference = GameObject.Find("Player").GetComponent<PlayerHealthController>();
    }

    //RESPAWN
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerCo());
    }

    //Corrutina
    private IEnumerator RespawnPlayerCo()
    {
        //Desactivamos al jugador
        _pCReference.gameObject.SetActive(false);
        //Esperamos un tiempo
        yield return new WaitForSeconds(waitToRespawn);
        //Reactivamos al jugador
        _pCReference.gameObject.SetActive(true);
        //Pos de respawm
        _pCReference.transform.position = _cReference.spawnPoint;
        //Vida del jugador al máximo
       // _pHReference.currentHealth = _pHReference.maxHealth;
        //Actualizar UI
        //_uIReference.UpdateHealthDisplay();
    } 
}