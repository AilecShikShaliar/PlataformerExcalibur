using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlataform : MonoBehaviour
{
    public Transform[] points;

    public float moveSpeed;

    public int currentPoint;

   public Transform _plataformPosition;


    // Update is called once per frame
    void Update()
    {
        _plataformPosition.position = Vector3.MoveTowards(_plataformPosition.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(_plataformPosition.position, points[currentPoint].position) < 0.01f)
        {
            currentPoint++;
        }
    }
       
}
