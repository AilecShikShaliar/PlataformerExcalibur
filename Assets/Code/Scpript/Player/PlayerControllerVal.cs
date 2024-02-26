 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerVal : MonoBehaviour
{
    //Velocidad
    public float moveSpeed;
    //Salto
    public float jumpForce;

    //Jugador est� en el suelo
    public bool _isGrounded;
    //Detectar suelo
    public Transform graundCheckPoint;
    //Referencia a las Layer del suelo
    public LayerMask whatIsGraund;
    //Doble salto
    private bool _canDubleJump;

    //RB del jugador
    private Rigidbody2D _theRB;
    //Referencia al Animator
    private Animator _anim;
    //Referencia al SpriteRenderer
    private SpriteRenderer _theSR;
    
    void Start()
    {
        //RB del jugador
        _theRB = GetComponent<Rigidbody2D>();

        //Animator del jugador 
        _anim = GetComponent<Animator>();

        //SpriteRendered del jugador
        _theSR = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        //input = Input.GetAxisRaw("Horizontal");

        _theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, _theRB.velocity.y);

        _isGrounded = Physics2D.OverlapCircle(graundCheckPoint.position, .2f,whatIsGraund);

        if(Input.GetAxisRaw("Horizontal") !=0f)
        {
            _anim.SetFloat("moveSpeed", (Input.GetAxisRaw("Horizontal") * moveSpeed));
        }
        else
        {
            _anim.SetFloat("moveSpeed", 0f);
        }

             //BOTON DE SALTO
             if (Input.GetButtonDown("Jump"))
                { 
                    //si el jugador est� en el suelo
                    if (_isGrounded)
                    {
                        _theRB.velocity = new Vector2(_theRB.velocity.x, jumpForce);

                        _canDubleJump = true;
                    }

                    else
                    { 
                        if (_canDubleJump)
                        {
                            _theRB.velocity = new Vector2(_theRB.velocity.x, jumpForce);

                            _canDubleJump = false;
                        }
                    }

                }

       Debug.Log("velocidad: " + (Input.GetAxisRaw("Horizontal") * moveSpeed));
        


        _anim.SetBool("isGrounded", _isGrounded);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       

        if (collision.gameObject.tag == "ground")
        {
            _isGrounded = true;
            
        }
        else _isGrounded = false;
    }


}
