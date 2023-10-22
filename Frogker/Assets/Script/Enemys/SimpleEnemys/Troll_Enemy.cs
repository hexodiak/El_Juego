using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll_Enemy : MonoBehaviour
{
    #region Variables
    //Variables de unity
    public Animator animator;
    public Transform attackpoint;

    //Variables de script

    

    //Variables script
    public float attackRange = 0.3f;
    public LayerMask playerLayer;
    public int attackdamage = 10;
    public float attackRate = 17f;
    private float nextAttack = 1.0f;

    #endregion


    #region Melee Fighting behavior

     
    void Update()
    {

        //Melee side attack
        if (Time.time > nextAttack) 
        {
            
            Attack(attackpoint);
            nextAttack = Time.time + attackRate;

        }
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

    #endregion


}
