using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinematicNormal : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public float DesactiveDirector;

    public GameObject dialogue;




  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playableDirector != null )
        {
            playableDirector.Play();
            PlayerController.instance.canMove = false;
            StartCoroutine(Disable());
            
           
        }
        
    }
     private IEnumerator Disable()
   {
     yield return new WaitForSeconds(DesactiveDirector);
     gameObject.SetActive(false);
      PlayerController.instance.canMove = true; 
   }
   
}
