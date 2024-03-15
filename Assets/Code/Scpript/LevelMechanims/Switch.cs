using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject objectToSwitch;

    private bool _activateSwitch;

    public GameObject infoPanel;

    private SpriteRenderer _sR;

    private PlayerControllerVal _val;

    // Start is called before the first frame update
    void Start()
    {
        _sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F) && _val.canInteracrt)
        {
            //objectToSwitch.GetComponent<Puerta>().ActivateObject();
        }
    }
}
