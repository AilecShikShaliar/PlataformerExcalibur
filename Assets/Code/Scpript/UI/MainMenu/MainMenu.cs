using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //CAMBIO DE ESCENAS

public class MainMenu : MonoBehaviour
{
    #region VARAIBLES

    public string startScene, continueScene;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QuittingGame");
    }
  
}
