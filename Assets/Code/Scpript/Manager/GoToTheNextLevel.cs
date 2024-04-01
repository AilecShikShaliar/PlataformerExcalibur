using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToTheNextLevel : MonoBehaviour
{
    public int sceneBuildIndex;
    public Vector2 PlayerPosition;
    public VectorValue PlayerStorage;

    //LEVEL ZONE ENTER, If Collaider is a Player
    //Move game another Scene
  private void OnTriggerEnter2D (Collider2D other)
  {
    print("Trigger Entered");

    if(other.tag == "Player")
    {
       PlayerStorage.initialValue = PlayerPosition;
        print("Swichting Scene to " + sceneBuildIndex);
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);

    }
  }
}
