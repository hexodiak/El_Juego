using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Troll_Enemy : MonoBehaviour
{
    #region Variables Generales

    //Variables de unity
    public Animator animator;//animador de movimientos
    public Transform attackpoint;//transform del ataque melee


    #endregion


    #region Variables Melee Fighting behavior

    //Variables script
    public float attackRange = 3f;//para seguir al jugador
    public float attackMeleeRange = 0.5f;//rango de ataque melee
    public LayerMask playerLayer;//layer para atacar solo al jugador
    public int attackdamage = 10;//damage del troll
    public float attackRate = 17f;//variable para el ataque y circunferencia
    private float nextAttack = 1.0f;//controlar el siguiente ataque con cooldown

    #endregion

    void Update()
    {
        LookAtPlayer();//Voltear al jugador


    }

    #region Melee Attack with wait seconds

    public void MeleeAttack()
    {

        //Player in range
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackpoint.position, attackMeleeRange, playerLayer);

        //Damage him
        foreach (Collider2D player in hitPlayer)
        {

            player.GetComponent<PlayerStats>().TakeDamagePlayer(attackdamage);
        }


    }

    public IEnumerator waitThreeSeconds()//Metodo para esperar segundos
    {
        
        yield return new WaitForSeconds(2);
        

    }

    #endregion



    void OnDrawGizmosSelected()
    {

        if (attackpoint == null)
            return;

        Gizmos.DrawWireSphere(attackpoint.position, attackMeleeRange);
        Gizmos.DrawWireSphere(this.gameObject.transform.position, attackRange);
    }

   

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
