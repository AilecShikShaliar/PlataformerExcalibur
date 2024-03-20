using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

        void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            
           transform.position = new Vector2(-16.35f, 2.15f);
        }
        
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
           
            transform.position = new Vector2(-16.35f, 0.41f);
        }

        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
           
            transform.position = new Vector2(-16.35f, -1.3f);
        }

        if(transform.position.y == 2.15f && Input.GetKeyDown(KeyCode.Space))
        {
          
            SceneManager.LoadScene("Nexo");
        }

        
    }
}
