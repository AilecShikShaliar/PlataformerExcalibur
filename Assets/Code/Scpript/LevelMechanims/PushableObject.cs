using UnityEngine;
using System.Collections;

public class PushableObject : MonoBehaviour
{

    public bool canPush;
    private Rigidbody2D _rb;
    private PlayerController _pCref;
    public bool isMovable;
    public bool onStairs;
    private void Start()
    {
        isMovable = false;
        canPush = false; 
        _rb = GetComponent<Rigidbody2D>();
        _pCref = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && canPush == true)
        {
            isMovable = true;
            _pCref.canRun = false;
            _rb.mass = 30.0f;
        }
        else
        {
            isMovable = false;
            _pCref.canRun = true;
            _rb.mass = 100.0f;
        }
       
    }
   private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Find("collaiderlibrary").GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.Find("collaiderlibrary").GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPush = true;
        }
        else
        {
            canPush = false;
        }
    }


}
