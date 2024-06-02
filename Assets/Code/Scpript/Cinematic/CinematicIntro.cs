using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinematicIntro : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public float DesactiveDirector;

    public GameObject dialogue;

    public int Csi = 0;

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
   
    }

    // Update is called once per frame
    void Update()
    {
        if(playableDirector != null && Csi == 0)
        {
            playableDirector.Play();
            PlayerController.instance.canMove = false;
            Cinematicant();
           StartCoroutine(Disable());
        }
        
    }
     private IEnumerator Disable()
   {
     yield return new WaitForSeconds(DesactiveDirector);
     gameObject.SetActive(false);
      PlayerController.instance.canMove = true; 
      dialogue.SetActive(true);
   }
   public void Cinematicant()
    {
       
        PlayerPrefs.SetInt("Csi", 1);
    }
}