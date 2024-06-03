using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public Transform[] points;

    public int currentPoint;

    public Transform _cursorPosition;

    public LSUIController lSUIController;

     void Start()
    {
        currentPoint = 0;

    }

    void Update()
    {
        Debug.Log("EstamosEn" + currentPoint);

        _cursorPosition.position = points[currentPoint].position;
        //_cursorPosition.position = new Vector2(Input.GetAxis("Vertical")

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (currentPoint == 0) currentPoint = 2;
            else currentPoint--;
            AudioManager.audioReference.PlaySFX(0);


        }
        if ( Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            
            if (currentPoint == points.Length - 1) currentPoint = 0;
            else currentPoint++;
            AudioManager.audioReference.PlaySFX(0);
        }
        
        if (currentPoint == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ExitLevelCo(10));
            AudioManager.audioReference.PlaySFX(1);
        }
        if (currentPoint == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            QuitGame();
            AudioManager.audioReference.PlaySFX(1);
        }
    }

    public void QuitGame()
    {
        
        Application.Quit();
        
        Debug.Log("Quitting Game");
    }

    public IEnumerator ExitLevelCo(int Scene)
    {
        lSUIController.FadeToBlack();
        PlayerPrefs.SetFloat("life", 100.0f);
        PlayerPrefs.SetInt("BookCollected", 0);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(Scene);
        PlayerPrefs.SetInt("Csi", 0);
        

    }
}
