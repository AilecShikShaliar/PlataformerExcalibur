using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    public GameObject Player;

    public Vector2 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.instance == null)
        Instantiate(Player, initialPosition, transform.rotation);

        else
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
