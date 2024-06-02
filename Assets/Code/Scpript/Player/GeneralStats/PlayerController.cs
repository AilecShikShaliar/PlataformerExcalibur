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
    //Temporizador sin Input
    public float noMoveLength;
    private float noMoveCount;

    //EjeXY
    public bool isLookingRight;

    public bool _canInteracrt;

    //RB del jugador
    public Rigidbody2D theRB;
    //Referencia al Animator
    public Animator anim;
    //Referencia al SpriteRenderer
    private SpriteRenderer _theSR;
    //Velocidad al correr
    public float actualSpeed;

    public Sprite thePlayerSprite;
    //Singleton
    public static PlayerController instance;

    public string areaTransitionName;

    public bool changed;
    //public Vector2 initialPosition;

    

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
        anim = GetComponent<Animator>();

        //SpriteRendered del jugador
        _theSR = GetComponent<SpriteRenderer>();

        isLookingRight = true;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        /*if (player != null && !changed)
        {
            if (player.transform.position.x != initialPosition.x)
            {
                changed = true;
                player.transform.position = initialPosition;
            }
        }*/
        //BOTÓN DE CORRER
        if (canMove)
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

                    anim.SetFloat("moveSpeed", (Input.GetAxisRaw("Horizontal") * moveSpeed));
                    anim.SetBool("canMove", true);
                    runMode = 2f;
                }
                else
                {
                    runMode = 1f;
                    anim.SetFloat("moveSpeed", (Input.GetAxisRaw("Horizontal") * moveSpeed));
                    anim.SetBool("canMove", false);

                }
            }
            else
            {
                anim.SetFloat("moveSpeed", 0f);
                anim.SetBool("canMove", false);
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


        anim.SetBool("LookingRight", isLookingRight);
        anim.SetBool("isGrounded", isGrounded);
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
    public void InitializeNoInput()
    {
        //Inicializamos el contador de no Input
        noMoveCount = noMoveLength;
        //Paramos al jugador
        theRB.velocity = Vector2.zero;
    }

}
