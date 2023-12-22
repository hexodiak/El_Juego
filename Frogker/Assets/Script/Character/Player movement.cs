using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    #region Variables Movimiento, salto, crouch

    private float horizontal; // Definir direccion
    private float verticalVelocity;
    private float speed = 5f; // Velocidad total
    private float jumpingPower = 6f; // Potencia de salto
    //private float jumpHeight = 0; //prueba
    private bool isFacingRight = true; // Definir X
    private bool doubleJump; // Controla el segundo salto en el aire
    private bool crounch; // identificador de estar agachado funciona junto con el groundcheck

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
    private float dashinPower = 10f;
    private float dashinTime = 0.2f;
    private float dashinCooldown = 0.5f;

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
    #endregion



    private void Awake()
    {
        _animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // X | -1 0 1
        _animation.SetFloat("Speed", Mathf.Abs(horizontal));//running animation

        _animation.SetBool("isJumping", !isGrounded());
        _animation.SetBool("isSliding", isWallSliding);

        if (!isGrounded())
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("Air Attack");
                _animation.SetTrigger("attack");
            }

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            crounch = true;
            _animation.SetBool("Crawl", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            crounch = false;
            _animation.SetBool("Crawl", false);
        }

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
                RB.velocity = new Vector2(RB.position.x, jumpingPower); //codigo de salto
                doubleJump = !doubleJump;
            }
                        
        }

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
        RB.gravityScale = 2f;
        RB.velocity = new Vector2(transform.localScale.x * dashinPower, 1f);
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
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

            if (isGrounded())
            {
                feetDust.Play();
            }
        }
    }
}
