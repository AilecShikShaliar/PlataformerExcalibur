using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exitarea : MonoBehaviour
{
    public string sceneToLoad;
    public string areaTransitionName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetString("areaTransitionNameV", areaTransitionName);
            SceneManager.LoadScene(sceneToLoad);

        }
    }
}