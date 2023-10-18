using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    #region Variables
    //Variables de unity
    public Animator animator;
    public Transform attackpoint;
    public Transform attackPointUp;
    public Transform attackPointDownGrounded;

    //Variables script
    public float attackRange = 0.3f;
    public LayerMask enemyLayers;
    public int attackdamage = 10;
    public float attackRate = 3f;


    #endregion
    

    #region Melee Attack
    void Update()
    {
        //Melee side attack
        if (Input.GetButtonDown("Fire1")) //!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) &&
        {
            Debug.Log("Ataque de lado");
            Attack(attackpoint);
            //nextAttackTime = Time.time + 1f / attackRate;

        }
    }

    void Attack(Transform AttackPoint)
    {
        //Play an attack animation
        animator.SetTrigger("MeleeAttack");

        //Enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

        //Damage then
        foreach (Collider2D enemy in hitEnemies)
        {
            //Debug.Log("Hit " + enemy.name);

            enemy.GetComponent<Troll_Enemy>().TakeDamage(attackdamage);
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
