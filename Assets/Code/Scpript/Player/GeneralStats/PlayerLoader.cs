using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    public GameObject Player;

    public Vector2 initialPosition;

    public bool changed = false;
    

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.instance == null)
        {
            GameObject player = Instantiate(Player, initialPosition, transform.rotation);
            print(player.transform.position);
            FindObjectOfType<CameraController>().LoadPlayer();
            Debug.Log("hola");
        }


        else
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
