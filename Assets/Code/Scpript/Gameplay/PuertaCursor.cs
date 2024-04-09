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

    private Puerta _puertaYah;
    public int scene;

    

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

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (currentPoint == 0) currentPoint = 1;
            else currentPoint--;


        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {

            if (currentPoint == points.Length - 1) currentPoint = 0;
            else currentPoint++;
        }

        if (currentPoint == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            _puertaYah.LoadLevel(scene);
        }

        if (currentPoint == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            _puertaM.Reanudar();
            
        }

    }
    }
