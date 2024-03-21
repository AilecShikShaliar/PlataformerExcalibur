using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Switch : MonoBehaviour
{
    //refs
public GameObject objectToSwitch;
public Sprite downsprite, upsprite;
// public Animator upanim, downanim;
private bool _activateSwitch;
public GameObject infopanel;
private SpriteRenderer _sR;
private PlayerControllerJack _pCRefernce;

// Start is called before the first frame update
void Start()
{
    _sR = GetComponent<SpriteRenderer>();
    _pCRefernce = GameObject.Find("Player").GetComponent<PlayerControllerJack>();
}

// Update is called once per frame
void Update()
{
    if (Input.GetKeyDown(KeyCode.F) && _pCRefernce.canInteract)
    {
        //si el objeto está desactivado
        if (objectToSwitch.GetComponent<ObjectActivator>().isActive == false)
        {
            objectToSwitch.GetComponent<ObjectActivator>().ActivateObject();

            objectToSwitch.GetComponent<ObjectActivator>().isActive = true;

        }
        else
        {
            objectToSwitch.GetComponent<ObjectActivator>().DeactivateObject();
            objectToSwitch.GetComponent<ObjectActivator>().isActive = false;
        }
    }
}

private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
        infopanel.SetActive(true);
        collision.GetComponent<PlayerControllerJack>().canInteract = true;
    }
}

 private void OnTriggerExit2D(Collider2D collision)
 {
    if (collision.CompareTag("Player"))
    {
        infopanel.SetActive(false);
        collision.GetComponent<PlayerControllerJack>().canInteract = false;
    }
 }

}