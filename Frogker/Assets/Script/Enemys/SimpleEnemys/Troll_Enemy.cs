using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Troll_Enemy : MonoBehaviour
{
    #region Variables
    //Variables de unity
    public Animator animator;
    public Transform attackpoint;
    Seeker seeker;
    AIPath aI;
    

    //Variables script
    public float attackRange = 5f;
    public LayerMask playerLayer;
    public int attackdamage = 10;
    public float attackRate = 17f;
    private float nextAttack = 1.0f;

    #endregion


    #region Melee Fighting behavior
    void Start()
    {
        seeker = GetComponent<Seeker>();
        aI = GetComponent<AIPath>();
    }

    //void Update()
    //{

    //Melee side attack
    //if (Time.time > nextAttack) 
    //{

    //Attack(attackpoint);
    // nextAttack = Time.time + attackRate;

    //}
    //}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "OnAttack")
        {
            aI.enabled = false;
            Attack(attackpoint);
            StartCoroutine(waitThreeSeconds());
        }
    }

    IEnumerator waitThreeSeconds()
    {
        yield return new WaitForSeconds(2);
        aI.enabled = true;

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
