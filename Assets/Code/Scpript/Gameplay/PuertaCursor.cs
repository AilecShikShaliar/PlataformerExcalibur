using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaCursor : MonoBehaviour
{
    public RectTransform[] points;

    public int currentPoint;

    public RectTransform _cursorPosition;

    private PuertaMenu _puertaM;

    public Puerta _puertaYah;

    public int scene;

    private PauseMenu _pMenuRef;


    private void Awake()
    {
        _puertaM = GameObject.Find("LevelManager").GetComponent<PuertaMenu>();
       


    }
    void Start()
    {
        currentPoint = 0;
    }

    void Update()
    {

        _cursorPosition.position = points[currentPoint].position;
        //_cursorPosition.position = new Vector2(Input.GetAxis("Vertical")

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (currentPoint == 0) currentPoint = 1;
            else currentPoint--;
            AudioManager.audioReference.PlaySFX(3);


        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (currentPoint == points.Length - 1) currentPoint = 0;
            else currentPoint++;
            AudioManager.audioReference.PlaySFX(3);
        }

        if (currentPoint == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            _puertaYah.LoadLevel(scene);
            _puertaM.Reanudar();
            Debug.Log("Hey, no se abre");
            
        }

        if (currentPoint == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            _puertaM.Reanudar();
            
            
        }

    }
    }
