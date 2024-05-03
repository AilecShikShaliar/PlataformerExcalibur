using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puertainterect : MonoBehaviour
{
    public Animator puertaanim;
    private PuertaMenu _puertaM;
    private bool _iHaveKey;
    private bool _canopendoor = false;
    private PlayerController _PCRef;
    private SpriteRenderer _sR;
    private LevelManager _lReference;

    // Start is called before the first frame update
    void Start()
    {
        puertaanim = GetComponent<Animator>();
        if (FindObjectOfType<PlayerController>()) _PCRef = FindObjectOfType<PlayerController>();
        _sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _canopendoor == true)

        {
            puertaanim.SetTrigger("openDoor");
            _iHaveKey = true;


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _canopendoor = true;
           

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _canopendoor = false;
            

        }
    }

    public void LoadLevel(int n)
    {
        _PCRef.enabled = false;
        StartCoroutine(_lReference.ExitLevelCo(n));

    }
}
