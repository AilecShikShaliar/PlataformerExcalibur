 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerJack: MonoBehaviour
{
    #region VARIABLE Y REFERENCIAS
    //Velocidad
    public float moveSpeed;
    //Salto
    public float jumpForce;
    //Velocidad Correr
    public float runMode;

    //Jugador est� en el suelo
    private bool _isGrounded;
    //Detectar suelo
    public Transform graundCheckPoint;
    //Referencia a las Layer del suelo
    public LayerMask whatIsGraund;
    
    //correr
    private bool _canRun;
    //Fuerza de rebote del jugador
    public float bounceForce;

    private bool _canMove = true;


    //EjeXY
    public bool isLookingRight;

    public bool canInteract = false;

    //RB del jugador
    private Rigidbody2D _theRB;
    //Referencia al Animator
    private Animator _anim;
    //Referencia al SpriteRenderer
    private SpriteRenderer _theSR;
    //Velocidad al correr
    public float actualSpeed;

    public VectorValue startingPosition;

    #endregion

    #region UNITY METHODS
    void Start()
    {
        //RB del jugador
        _theRB = GetComponent<Rigidbody2D>();

        //Animator del jugador 
        _anim = GetComponent<Animator>();

        //SpriteRendered del jugador
        _theSR = GetComponent<SpriteRenderer>();

        isLookingRight = true;
         
         transform.position = startingPosition.initialValue;
    }

   
    void Update()
    {
        //BOTÓN DE CORRER
       

        _isGrounded = Physics2D.OverlapCircle(graundCheckPoint.position, .2f,whatIsGraund);

        
        
        
        if (Input.GetAxisRaw("Horizontal") > 0.1f) isLookingRight = true;
        else if (Input.GetAxisRaw("Horizontal") < -0.1f) isLookingRight = false;
        

        if (Input.GetAxisRaw("Horizontal") !=0f && _canMove)
        {
            

            
            _canRun = true;
            _theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * runMode, _theRB.velocity.y);
        
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
            _canRun = false;
        }
        actualSpeed = Input.GetAxisRaw("Horizontal") * moveSpeed * runMode;
             //BOTON DE SALTO
             if (Input.GetButtonDown("Jump"))
                { 
                    //si el jugador est� en el suelo
                    if (_isGrounded)
                    {
                        _theRB.velocity = new Vector2(_theRB.velocity.x, jumpForce);

                        
                        AudioManager.audioReference.PlaySFX(2);
                    }


                }
        

        Debug.Log("velocidad: " + (Input.GetAxisRaw("Horizontal") * moveSpeed));


        _anim.SetBool("LookingRight", isLookingRight);
        _anim.SetBool("isGrounded", _isGrounded);
    }

    

    #endregion

    #region MY METHODS
    void OnCollisionEnter2D(Collision2D collision)
    {

        //if (collision.gameObject.CompareTag("Plataform"))
            //transform.parent = collision.transform;

        if (collision.gameObject.tag == "ground")
        {
            _isGrounded = true;
            
        }
        else _isGrounded = false;
    }
    //METODO CUANDO EL JUGADOR ENTRA EN COLISIÓN CON UN OBJETO

    //private void OnCollisionExit2D(Collision2D collision)
    //{
        //if (collision.gameObject.CompareTag("Plataform"))
            //transform.parent = null;
    //}



    #endregion

}
