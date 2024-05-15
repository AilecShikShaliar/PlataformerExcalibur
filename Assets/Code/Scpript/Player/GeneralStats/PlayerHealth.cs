using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maximoVida;

    [SerializeField] private LifeBar _lifeBar;

    [HideInInspector] public int currentHealth;
    public int maxHealth;
    public float invincibleLength;
    private float _invincibleCounter;

    public float neneqdano;

    //Referencias
    private UIController _uIReference;
    private PlayerController _pCReference;
    private SpriteRenderer _sR;
    private LevelManager _lReference;
    public GameObject deathEffect;
    public bool playerDead = false;
    //private GameOverMenu _gOMenu;
    private LifeBar _lifeRef;

    private void Awake()
    {
        //_gOMenu = GameObject.Find("LevelManager").GetComponent<GameOverMenu>();
    }
    // Start is called before the first frame update
    void Start()
    {

        _lifeBar = GameObject.Find("life").GetComponent<LifeBar>();
        _lifeRef = GameObject.Find("life").GetComponent<LifeBar>();


        _uIReference = GameObject.Find("Canvas").GetComponent<UIController>();
        _pCReference = GetComponent<PlayerController>();
        _sR = GetComponent<SpriteRenderer>();
        _lReference = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (_invincibleCounter > 0)
        {
            //Resta 1 cada segundo
            _invincibleCounter -= Time.deltaTime;

            //Si el contador 0
            if (_invincibleCounter <= 0)
                //Cambiamos el color del sprite, mantenemos el RGB y ponemos la opacidad a tope
                _sR.color = new Color(_sR.color.r, _sR.color.g, _sR.color.b, 1f);
        }

    }
    //public void Daño(float daño)
    //{
    //    vida -= daño;
    //    _lifeBar.RestarVida(vida);
    //    if (vida <= 0) Destroy(gameObject);
    //}

    public void DealWithDamage()
    {

        //Si ya no somos invencibles
        if (_invincibleCounter <= 0)
        {
            //Restamos 1 de la vida que tengamos
            _lifeRef.currentHealth--; //_currentHealth -= 1 <=> _currentHealth = _currentHealth - 1 <=> _currentHealth--
            

            if (currentHealth <= 0)
            {
                //Vida 0 si se queda en negativo
                currentHealth = 0;
                //_gOMenu.GameOver();
                playerDead = true;
                _pCReference.gameObject.SetActive(false);






                //audio manager, sonido de muerte

                //EFECTO DE MUERTE 
                GameObject instance = Instantiate(deathEffect, transform.position, transform.rotation); //inicia el efecto de muerte
                                                                                                        //donde mira
                //instance.GetComponent<PlayerDeathEffect>().seeLeft = GetComponent<PlayerController>().seeLeft;




            }
            //Si recibe daño pero no muere
            else
            {
                //Inicializamos el contador de invencibilidad
                _invincibleCounter = invincibleLength;
                //Cambiamos el color del sprite, mantenemos el RGB y ponemos la opacidad a la mitad
                _sR.color = new Color(_sR.color.r, _sR.color.g, _sR.color.b, .5f);
                
                playerDead = false;
            }

          
        }

    }

    //MÉTODO PARA CURAR AL JUGADOR
    public void HealPlayer()
    {
        //curamos a vida máxima
        //currentHealth = maxhealth
        //+1 vida de jugador

        currentHealth++;

        //si la vida actual es mayor que la máxima
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
           
        }
    }

}
