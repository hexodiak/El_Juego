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
    private float horizontal; // Definir direccion
    private bool isFacingRight = true;//movimiento

    public float attackRange = 0.5f;//rango de ataque melee
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
        horizontal = rb.velocityX;
        Flip();
    }

    public void MeleeAttack()
    {
        aI.canMove = false;//variable del AI para controlar la inteligencia si moverse o no
        Attack(attackpoint);
        StartCoroutine(waitThreeSeconds());
        
    }

    IEnumerator waitThreeSeconds()
    {
        yield return new WaitForSeconds(2);
        aI.canMove = true;//variable del AI para controlar la inteligencia si moverse o no

    }

    void Attack(Transform AttackPoint)
    {
        //Play an attack animation
        animator.SetTrigger("TrollAttack");

        //Player in range
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, playerLayer);

        //Damage him
        foreach (Collider2D player in hitPlayer)
        {

            player.GetComponent<PlayerStats>().TakeDamagePlayer(attackdamage);
        }

    }

    void OnDrawGizmosSelected()
    {

        if (attackpoint == null)
            return;

        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }


    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

            
        }
    }
    #endregion


}
