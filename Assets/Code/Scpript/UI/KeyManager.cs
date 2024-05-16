using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public LevelManager _lMReference;
    public GameObject keyobj;
    // Start is called before the first frame update
    void Start()
    {
        _lMReference = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        if (_lMReference.bookcollected >= 5)
        {

            keyobj.SetActive(true);
        }
        else keyobj.SetActive(false);
    }

    public void UptadeKeyState()
    {
        if (_lMReference.bookcollected >= 5)
        {
            keyobj.SetActive(true);
        }
        else keyobj.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
