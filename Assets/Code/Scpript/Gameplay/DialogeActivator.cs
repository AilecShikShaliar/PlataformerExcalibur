using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogeActivator : MonoBehaviour
{
   public string[] lines;
   private bool canActive;
   public Sprite CheckPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canActive && Input.GetKeyDown(KeyCode.F) && !DialogueManager.instance.dialogBox.activeInHerachy)
        {
            DialogueManager.instance.ShowDialog(lines, theNpcSprite);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            canActive = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canActive = false;
    }
}
