using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinematicIntro : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public float DesactiveDirector;

    public GameObject dialogue;

    public int Csi;

    public static CinematicIntro instance;



  void Awake ()
  {
    if (instance == null)
    {
        instance = this;
    }
  }

    // Start is called before the first frame update
    void Start()
    {
       if (PlayerPrefs.HasKey("Csi"))
       Csi = PlayerPrefs.GetInt("Csi");
     
   
    }

    // Update is called once per frame
    void Update()
    {
        if(playableDirector != null && Csi == 0)
        {
            playableDirector.Play();
            PlayerController.instance.canMove = false;
            StartCoroutine(Disable());
            Cinematicant();
            Debug.Log("ea");            
        }
        
  
        
    }
     private IEnumerator Disable()
   {
     yield return new WaitForSeconds(DesactiveDirector);
     gameObject.SetActive(false);
      PlayerController.instance.canMove = true; 
      dialogue.SetActive(true);
      Csi = 0; 
   }
   public void Cinematicant()
    {
       
       // PlayerPrefs.SetInt("Csi", 0);
        PlayerPrefs.SetInt("Csi", 1);
    }
   

}
