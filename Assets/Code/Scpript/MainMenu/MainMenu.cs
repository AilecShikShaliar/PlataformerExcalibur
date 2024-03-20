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
            
           transform.position = new Vector2(-16.35f, 0.4f);
        }
        
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
           
            transform.position = new Vector2(-16.35f, -1.44f);
        }

        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
           
            transform.position = new Vector2(-16.35f, -3.22f);
        }

        if(transform.position.y == 0.4f && Input.GetKeyDown(KeyCode.Space))
        {
          
            SceneManager.LoadScene("Nexo");
        }

        
    }
}
