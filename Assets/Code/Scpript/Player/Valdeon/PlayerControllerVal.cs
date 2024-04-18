 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerVal : MonoBehaviour
{
    #region VARIABLE Y REFERENCIAS
    
    private bool _canDubleJump;

    //private Rigidbody2D _theRB;

    private bool _dashMove;

    public float dashForce;

    private Animator _anim;

    private SpriteRenderer _theSR;

    


    #endregion

    #region UNITY METHODS
    void Start()
    {
        

        //Animator del jugador 
        _anim = GetComponent<Animator>();

        //SpriteRendered del jugador
        _theSR = GetComponent<SpriteRenderer>();

        
    }

   
    void Update()
    {
        //BOTÓN DE CORRER
       

        if(Input.GetAxisRaw("Horizontal") != 0f || GetComponent<PlayerController>().theRB.velocity.y != 0)
        if (!_dashMove && GetComponent<PlayerController>().canMove) Dash();

        if (GetComponent<PlayerController>().isGrounded)
        {
            _canDubleJump = true;
        }

        //BOTON DE SALTO
        if (Input.GetButtonDown("Jump"))
        { 
                        if (_canDubleJump)
                        {
                         GetComponent<PlayerController>().theRB.velocity = new Vector2(GetComponent<PlayerController>().theRB.velocity.x, GetComponent<PlayerController>().jumpForce);

                            _canDubleJump = false;
                            AudioManager.audioReference.PlaySFX(4);
                        }
                    

        }
        

    }

    

    #endregion

    #region MY METHODS
  

    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("dash");

            StartCoroutine(DashCo());

            
        }

    }

    private IEnumerator DashCo()
    {
        _anim.SetTrigger("dashTrigger");


        GetComponent<PlayerController>().canMove = false;
        _dashMove = true;
        int n;
        if (GetComponent<PlayerController>().isLookingRight) n = 1; else n = -1;
        GetComponent<PlayerController>().theRB.velocity = new Vector2(dashForce * n,GetComponent<PlayerController>().theRB.velocity.y);
        AudioManager.audioReference.PlaySFX(0);

        yield return new WaitForSeconds(.5f);

        GetComponent<PlayerController>().canMove = true;
        _dashMove = false;


    }

    #endregion

}
