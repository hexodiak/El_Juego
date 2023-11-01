using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Troll_Enemy : MonoBehaviour
{
    #region Variables
    //Variables de unity
    public Rigidbody2D rb;
    public Animator animator;//animador de movimientos
    public Transform attackpoint;//transform del ataque melee
    AIPath aI;//variable del AI para controlar la inteligencia si moverse o no


    //Variables script
    public float attackRange = 3f;//para seguir al jugador
    public float attackMeleeRange = 0.5f;//rango de ataque melee
    public LayerMask playerLayer;//layer para atacar solo al jugador
    public int attackdamage = 10;//damage del troll
    public float attackRate = 17f;//variable para el ataque y circunferencia
    private float nextAttack = 1.0f;//controlar el siguiente ataque con cooldown

    #endregion


    #region Melee Fighting behavior
    void Start()
    {
        
        aI = GetComponent<AIPath>();//variable del AI para controlar la inteligencia si moverse o no
    }

    void Update()
    {
        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("TrollAttack");
        }
        
        LookAtPlayer();
    }

    

    public void MeleeAttack()
    {
        aI.canMove = false;//el enemigo se queda quieto para empezar su ataque
        //Play an attack animation
        //animator.SetTrigger("TrollAttack");

        //Player in range
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackpoint.position, attackMeleeRange, playerLayer);

        //Damage him
        foreach (Collider2D player in hitPlayer)
        {

            player.GetComponent<PlayerStats>().TakeDamagePlayer(attackdamage);
        }


        StartCoroutine(waitThreeSeconds());

    }

    IEnumerator waitThreeSeconds()
    {
        animator.ResetTrigger("TrollAttack");
        yield return new WaitForSeconds(2);
        aI.canMove = true;//variable del AI para controlar la inteligencia si moverse o no

    }

    

    void OnDrawGizmosSelected()
    {

        if (attackpoint == null)
            return;

        Gizmos.DrawWireSphere(attackpoint.position, attackMeleeRange);
        Gizmos.DrawWireSphere(this.gameObject.transform.position, attackRange);
    }

    #endregion

    #region Flip enemy 

    public Transform player;
    public bool isFlipped = false;

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x < player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x > player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    #endregion
}
