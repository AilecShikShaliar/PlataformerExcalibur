using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinematicActive : MonoBehaviour
{
   public PlayableDirector playableDirector;
   public GameObject gameObject;

   public float DesactiveDirector;

   void OnTriggerEnter2D(Collider2D other)
   {
     if (other.CompareTag("Player"))
     {
        if(playableDirector != null)
        {
            playableDirector.Play();
            StartCoroutine(Disable());
        }
     }
   }

   private IEnumerator Disable()
   {
     yield return new WaitForSeconds(DesactiveDirector);
     gameObject.SetActive(false);
   }
}
