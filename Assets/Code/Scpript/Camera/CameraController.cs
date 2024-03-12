using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //POSICION DEL OBJETIVO DE LA CAMARA
    public Transform target;

    //POSICION MINIMA Y VERTICAL 
    public float minHeight, maxHeight;

    //POSICION DE LOS FONDOS
    public Transform farBg, middleBg;

    //REFERENCIA A LA ULTIMA POSICI�N DEL JUGADOR
    private Vector2 _lastPos;


    void Start()
    {
        _lastPos = transform.position;
    }


    private void LateUpdate()
    {
       //SIGUE AL JUGADO SIN VARIAR POSICION Z
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);
        
        //CUANTO HAY QUE MOVERSE EN LA X
        Vector2 _amountToMove = new Vector2(transform.position.x - _lastPos.x, transform.position.y - _lastPos.y);
        
        //COMO SE MUEVE EL FONDO A LA MISMA VELOCIDAD DEL JUGADOR
        farBg.position = farBg.position + new Vector3(_amountToMove.x, _amountToMove.y, 0f);
        middleBg.position -= new Vector3(_amountToMove.x, _amountToMove.y, 0f) * .1f;

        //ACTUALIZAR POSICION DEL JUGADOR
        _lastPos = transform.position;

    }
}
