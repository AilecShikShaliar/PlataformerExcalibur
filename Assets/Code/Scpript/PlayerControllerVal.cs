using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerVal : MonoBehaviour
{
    //Velocidad
    public float moveSpeed;
    //Salto
    public float jumpForce;

    //Jugador está en el suelo
    private bool _isGrounded;
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
        _theRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, _theRB.velocity.y);

        _isGrounded = Physics2D.OverlapCircle(graundCheckPoint.position, .2f,whatIsGraund);

        //BOTON DE SALTO
        /*if (Input.GetKeyDown("Jump"))
            { 
                //si el jugador esté en el suelo
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

            }*/

        Debug.Log("velocidad: " + (Input.GetAxis("Horizontal") * moveSpeed));

        _anim.SetFloat("moveSpeed",(Input.GetAxis("Horizontal") * moveSpeed));

        _anim.SetBool("isGrounded", _isGrounded);
    }



}
