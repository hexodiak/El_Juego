using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class Playermovement : MonoBehaviour
{
    #region Otros scripts
    Scorpion scorpion;

    #endregion

    #region Variables Movimiento, salto, crouch

    private float horizontal; // Definir direccion
    private float verticalVelocity;
    private float speed = 5f; // Velocidad total
    private bool isFacingRight = true; // Definir X
    private bool doubleJump; // Controla el segundo salto en el aire
    public Vector3 localScale;

    //Crouch
    private float m_CrouchSpeed = .6f;
    private bool crouch;//identificador de estar agachado funciona junto con el groundcheck

    
    private float jumpingPower = 9.5f; // Potencia de salto
    //Prueba para salto segun apretada la tecla
    public float jumpStartTime; 
    private float jumpTime; 
    private bool isJumping;

    #endregion

    #region Serialize para identificar

    [SerializeField] private Rigidbody2D RB; // identificador de rigidbody
    [SerializeField] private Transform groundCheck; //identificar el suelo
    [SerializeField] private LayerMask groundLayer;  // identificar los suelos
    [SerializeField] private TrailRenderer tr; // trail para dibujar un rastro
    [SerializeField] private Transform wallCheck; // identificar los objetos de paredes
    [SerializeField] private LayerMask wallLayer; // identificar los layer que son paredes

    #endregion

    #region Variables de Dash

    //Dash 
    private bool canDash = true;
    private bool isDashing;
    private float dashinPower = 5f;
    private float dashinTime = 0.2f;
    private float dashinCooldown = 0.1f;

    #endregion

    #region Variables del wall jump y sliding
    //Wall slide
    private bool isWallSliding;
    private float wallSlindingSpeed = 1.5f;

    //Wall Jump
    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(5f, 8f);

    #endregion

    #region Variables para animacion y efectos
    //Animations
    private Animator _animation;
    public ParticleSystem feetDust;

    //Crouch boxcollider2d
    public BoxCollider2D boxColliderToCrouch;//deactivate de upper collider to crouch
    #endregion

    private void Start()
    {
        scorpion = GetComponent<Scorpion>();
    }

    private void Awake()
    {
        _animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // X | -1 0 1
        _animation.SetFloat("Speed", Mathf.Abs(horizontal));//running animation

        _animation.SetBool("isJumping", !isGrounded());//!isGrounded()
        _animation.SetBool("isSliding", isWallSliding);
        //_animation.SetBool("is", isWallSliding);

        if (!isGrounded())
        {
            if (Input.GetMouseButton(0))
            {
                //Debug.Log("Air Attack");
                //_animation.SetTrigger("attack");
            }

        }

        #region Crouch

        // Detectar si el jugador quiere agacharse
        if (Input.GetKeyDown(KeyCode.S))
        {
            crouch = true;
            boxColliderToCrouch.enabled = false;
            _animation.SetBool("Crouch", true);

        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            crouch = false;
            boxColliderToCrouch.enabled = true;
            _animation.SetBool("Crouch", false);
        }


        if (crouch)
        {
            // Mantener la velocidad reducida si está agachado
            float moveSpeed = crouch ? m_CrouchSpeed : speed;
            horizontal = horizontal * moveSpeed;
        }else { }
        


        #endregion

        #region Jump
        if (isGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;           
        }

        if(isDashing)
        {            
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {

            if (isGrounded() || doubleJump)
            {
                feetDust.Play();
                isJumping = true;
                jumpTime = jumpStartTime;
                RB.velocity = new Vector2(RB.position.x, jumpingPower); //codigo de salto
                doubleJump = !doubleJump; 
            }
                        
        }
        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTime > 0)
            {
                RB.velocity = new Vector2(RB.position.x, jumpingPower); //codigo de salto
                jumpTime -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
        _animation.SetFloat("yVelocity", RB.velocity.y);


        #endregion

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        WallSlice();
        WallJump();

        if (!isWallJumping)
        {
            Flip();
        }



        #region Validacion scorpion

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isGrounded())
            {

                scorpion.Attack();
            }
            else { Debug.Log("No esta en el piso"); }
            
        }

        #endregion
    }

    

    public bool isGrounded()
    {
        
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); // Crean un circulo en los pies para detectar suelo

    }

    private void FixedUpdate() //mover won
    {     

        if (isDashing)
        {
            return;
        }

        if (!isWallJumping)
        {
            RB.velocity = new Vector2(horizontal * speed, RB.velocity.y);
        }
  
        RB.velocity = new Vector2(horizontal * speed, RB.velocity.y);
        _animation.SetFloat("Velocity", math.abs(horizontal));
    }

 

    //Dash
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = RB.gravityScale;
        RB.gravityScale = 1f;
        if (Mathf.Sign(transform.localScale.x) < -1)
        {
            RB.velocity = new Vector2(transform.localScale.x * dashinPower * -1, 1f); //* -1
        }
        else
        {
            RB.velocity = new Vector2(transform.localScale.x * dashinPower, 1f); //* 1
        }
        tr.emitting = true;
        _animation.SetBool("isDashing", true);
        yield return new WaitForSeconds(dashinTime);
        tr.emitting = false;
        RB.gravityScale = originalGravity;
        isDashing = false;
        _animation.SetBool("isDashing", false);
        yield return new WaitForSeconds(dashinCooldown);
        
        canDash = true;
    }

    //Wall Slide
    private bool isWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
        
    }

    private void WallSlice()
    {
        if (isWalled() && !isGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            RB.velocity = new Vector2(RB.velocity.x, Mathf.Clamp(RB.velocity.y, -wallSlindingSpeed, float.MaxValue));
            
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            RB.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if(transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);

        }

        
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    //Flip
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            //transform.Rotate(0f, 180f, 0);
            localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;

            if (isGrounded())
            {
                feetDust.Play();
            }
        }
    }
}
