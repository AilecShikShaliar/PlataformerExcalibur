using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Text dialogText;
    public Image portarit;
    public GameObject dialogBox;
    public string[] dialogLines;
    public int currentLine;
    private bool justStarted;
    private string charName;
    private Sprite sNPC;

    public static DialogueManager.instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
