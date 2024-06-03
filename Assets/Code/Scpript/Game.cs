using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI textComponent;

    State stateRef; 

    [SerializeField] State startingState;

    public GameObject background;
    public Image imagen;

    public GameObject paneldialog;

    // Update is called once per frame
    void Update()
    {
        
        if (stateRef != null) ManageStates();

    }

    
    void ManageStates()
    {
        
        State[] nextStates = stateRef.GetNextStates();

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if(nextStates.Length > 0)
            {
                stateRef = nextStates[0];
                textComponent.text = stateRef.GetStateStoryText();
                imagen.sprite = stateRef.GetStateImage();
            }
            else
            {
                Debug.Log(stateRef.name);
                if (stateRef.name == "2TV")
                {
                    SceneManager.LoadScene("Nexo");
                }
                ResetDialog();
                paneldialog.SetActive(false);
                FindObjectOfType<PlayerController>().canMove = true;
                
                

            }

        }




    }

    public void LoadState(State estado)
    {
        stateRef = estado;

        textComponent.text = stateRef.GetStateStoryText();

        imagen = background.GetComponent<Image>();

        imagen.sprite = stateRef.GetStateImage();
    }

    public void ResetDialog()
    {
        stateRef = null;
        textComponent.text = "";
    }
}
