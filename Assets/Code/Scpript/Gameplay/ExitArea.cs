using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitArea : MonoBehaviour
{
    public string sceneToLoad;
    public string areTrasicionName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
            PlayerController.instance.areaTransitionName = areTrasicionName;
        }
    }
}
