using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSPlayer : MonoBehaviour
{
    public MapPoint currentPoint;
    private LoadLevelManager _lSReference;
    // Start is called before the first frame update
    void Start()
    {
         _lSReference = GameObject.Find("LoadLevelManager").GetComponent<LoadLevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
         

            if (currentPoint.isLevel)
            {
                
                if (Input.GetKeyDown(KeyCode.F))
                    
                    _lSReference.LoadLevel();
            }

    }

}
