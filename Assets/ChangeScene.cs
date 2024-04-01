using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public int sceneBuildIndex;
    public Vector2  playerPosition;
    public VectorValue playerStorage; 


    //LEVEL ZONE ENTER, If Collaider is a Player
    //Move game another Scene
  private void OnTriggerEnter2D (Collider2D other)
  {
    print("Trigger Entered");

    if(other.tag == "Player")
    {
        playerStorage.initialValue = playerPosition;
        print("Swichting Scene to " + sceneBuildIndex);
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);

    }
  }
}
