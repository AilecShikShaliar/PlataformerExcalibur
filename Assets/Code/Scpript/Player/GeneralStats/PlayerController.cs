using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Velocidad
    public float moveSpeed;
    //Salto
    public float jumpForce;
    //Velocidad Correr
    public float runMode;

    //Jugador est� en el suelo
    public bool isGrounded;
    //Detectar suelo
    public Transform graundCheckPoint;
    //Referencia a las Layer del suelo
    public LayerMask whatIsGraund;
    //correr
    public bool canRun;
    //Fuerza de rebote del jugador
    public float bounceForce;

    public bool canMove = true;

    //EjeXY
    public bool isLookingRight;

    public bool _canInteracrt;

    //RB del jugador
    public Rigidbody2D theRB;
    //Referencia al Animator
    private Animator _anim;
    //Referencia al SpriteRenderer
    private SpriteRenderer _theSR;
    //Velocidad al correr
    public float actualSpeed;

    public Sprite thePlayerSprite;
    //Singleton
    public static PlayerController instance;

    public string areaTransitionName;

    

    private void Awake()
    {
        if (instance == null) instance = this;
        else
            if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        //RB del jugador
        theRB = GetComponent<Rigidbody2D>();

        //Animator del jugador 
        _anim = GetComponent<Animator>();

        //SpriteRendered del jugador
        _theSR = GetComponent<SpriteRenderer>();

        isLookingRight = true;

    }

    // Update is called once per frame
    void Update()
    {
        //BOTÓN DE CORRER
        if(canMove)
        {
            isGrounded = Physics2D.OverlapCircle(graundCheckPoint.position, .2f, whatIsGraund);




            if (Input.GetAxisRaw("Horizontal") > 0.1f) isLookingRight = true;
            else if (Input.GetAxisRaw("Horizontal") < -0.1f) isLookingRight = false;


            if (Input.GetAxisRaw("Horizontal") != 0f)
            {



                canRun = true;
                theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * runMode, theRB.velocity.y);

                if (Input.GetKey(KeyCode.LeftShift))
                {

                    _anim.SetFloat("moveSpeed", (Input.GetAxisRaw("Horizontal") * moveSpeed));
                    _anim.SetBool("canMove", true);
                    runMode = 2f;
                }
                else
                {
                    runMode = 1f;
                    _anim.SetFloat("moveSpeed", (Input.GetAxisRaw("Horizontal") * moveSpeed));
                    _anim.SetBool("canMove", false);

                }
            }
            else
            {
                _anim.SetFloat("moveSpeed", 0f);
                _anim.SetBool("canMove", false);
                canRun = false;
            }
            actualSpeed = Input.GetAxisRaw("Horizontal") * moveSpeed * runMode;
            //BOTON DE SALTO
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("mierda");
                //si el jugador est� en el suelo
                if (isGrounded)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    AudioManager.audioReference.PlaySFX(4);
                }

            }
        }
        


        Debug.Log("velocidad: " + (Input.GetAxisRaw("Horizontal") * moveSpeed));


        _anim.SetBool("LookingRight", isLookingRight);
        _anim.SetBool("isGrounded", isGrounded);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        //if (collision.gameObject.CompareTag("Plataform"))
        //transform.parent = collision.transform;

        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;

        }
        else isGrounded = false;
    }

}
