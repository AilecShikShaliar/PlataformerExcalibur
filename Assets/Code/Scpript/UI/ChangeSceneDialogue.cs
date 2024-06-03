using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneDialogue : MonoBehaviour
{
    
    public string sceneName; 
    private Game _game;
    public GameObject paneldialog;



    // Start is called before the first frame update
  
    void Invoke ()
    {
        ChangeSceneDg();
    }
    // Update is called once per frame
    void ChangeSceneDg()
    {
        if (paneldialog == false)
         {
            
            paneldialog.SetActive(false);
            LoadScene();
         }
    }

   public static void LoadScene()
   {
     
     SceneManager.LoadScene("Nexo");
    
   } 
}
