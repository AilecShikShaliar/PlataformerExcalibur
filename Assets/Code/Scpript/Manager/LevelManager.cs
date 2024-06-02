using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    //Variable de tiempo para la corrutina
    public float waitToRespawn;

    //Refs
    private PlayerController _pCReference;
    private CheckpointController _cReference;
    private UIController _uIReference;
    private PlayerHealth _pHReference;
    private PuertaMenu _pMenu;
    //SALIR DEL NIVEL
    public string levelToLoad;
    public int keycollected;
    public int bookcollected;

    private CinematicIntro _cinematicIntro;
    
    

    
    private LSUIController _lSUIController;

    private void Start()
    {
        //Inicializamos las refs
        _lSUIController = GameObject.Find("LSCanvas").GetComponent<LSUIController>();
        if (FindObjectOfType<PlayerController>()) _pCReference = FindObjectOfType<PlayerController>();
        _cReference = GameObject.Find("CheckPointController").GetComponent<CheckpointController>();
        _pMenu = GameObject.Find("LevelManager").GetComponent<PuertaMenu>();
        _uIReference = GameObject.Find("Canvas").GetComponent<UIController>();
        _cinematicIntro = GameObject.Find("Gameplay") .GetComponent<CinematicIntro>();
        //_pHReference = GameObject.Find("Player").GetComponent<PlayerHealthController>();
         if (PlayerPrefs.HasKey("BookCollected"))
            bookcollected = PlayerPrefs.GetInt("BookCollected");
        
      
    

        
    }
    
    //RESPAWN
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerCo());
    }

    //CORRUTINAS
    public IEnumerator ExitLevelCo(int Scene)
    {
        _lSUIController.FadeToBlack();

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(Scene);
        
    }
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
        FindObjectOfType<LifeBar>().InicializarBarraDeVida(100.0f);
    } 
    public void RecogerLibro ()
    {
        bookcollected++;
        PlayerPrefs.SetInt("BookCollected", bookcollected);
        
    }
    
}