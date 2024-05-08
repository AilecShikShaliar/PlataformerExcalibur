using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Para trabajar con elementos de UI
using TMPro;

public class UIController : MonoBehaviour
{
    //Refs a las imágenes de las refs
    public Image healthBar;
    //Referencias a los sprites que cambian al ganar/perder salud
    //public Sprite heartFull, heartMid, heartLow, heartEmpty;
    private LevelManager _lMreference;
    //Refs al Script que controla la vida del jugador
    //private PlayerHealthController _pHReference;
    public TextMeshProUGUI currencytxt;
    private puertainterect _pIntec;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos la referencia al PlayerHealthController
        //_pHReference = GameObject.Find("Player").GetComponent<PlayerHealthController>();
        _lMreference = GameObject.Find("LevelManager").GetComponent<LevelManager>();
      
        //UpdateCurrency();
    }



    //M�todo para actualizar la vida en la UI
 
    //metodo dinero
    public void UpdateCurrency()
    {
        currencytxt.text = _lMreference.keycollected.ToString();

    }
}
