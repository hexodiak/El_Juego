using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    #region Variables
    //Variables de unity
    public Animator animator;

    //Transforms p
    public Transform attackPoint;
    public Transform attackPointUp;
    //public Transform attackPointDownGrounded; //aun no se usan

    //Variables para ataque melee
    public float attackRange = 0.3f;
    public LayerMask enemyLayers;
    public int attackdamage = 10;
    public float attackRate = 3f;
    float nextAttackTime = 3;

    //Variables para ataque de rango
    public Transform featherPoint; //donde sale la pluma
    public GameObject feather; //pluma
    float featherspeed = 10f;//velocidad pluma

    #endregion

    void Update()
    {
        #region Melee side attack
        if (Input.GetButtonDown("Fire1") && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)) //!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) &&
        {
            //if(nextAttackTime >= 3)
            //{
                //nextAttackTime = 0;
                Debug.Log("Ataque de lado");
                StickAttack(attackPoint);
                //nextAttackTime = Time.time + 1f / attackRate;
            //}
        }
        #endregion

        #region Melee Up Attack
        if (Input.GetButtonDown("Fire1") && Input.GetAxis("Vertical") > 0)
        {
            //if(nextAttackTime >= 3)
            //{
            //nextAttackTime = 0;
            Debug.Log("Ataque hacia arriba");
            StickAttack(attackPointUp);
            //nextAttackTime = Time.time + 1f / attackRate;
            //}
        }
        #endregion

        #region Range Feather Attack
        if (Input.GetButtonDown("Fire2")) 
        {
            FeatherAttack();
        }
        #endregion

        }
    #region Melee Attacks
    void StickAttack(Transform AttackPoint) //Stick attack
    {
        //Play an attack animation
        animator.SetTrigger("MeleeAttack");

        //Enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

        //Damage then
        foreach (Collider2D enemy in hitEnemies)
        {
            //Debug.Log("Hit " + enemy.name);

            enemy.GetComponent<EnemyBasic>().TakeDamage(attackdamage);
        }

    }

    void OnDrawGizmosSelected()
    {

        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    #endregion

    #region Range Attacks
    void FeatherAttack() //Feather attack
    {
        // Instanciar el proyectil en la posici�n y rotaci�n del firePoint
        GameObject featherprojectile = Instantiate(feather, featherPoint.position, featherPoint.rotation);

        // Obtener el Rigidbody2D del proyectil y asignarle velocidad en la direcci�n correcta
        Rigidbody2D rb = featherprojectile.GetComponent<Rigidbody2D>();
        float direction = Mathf.Sign(transform.localScale.x); // 1 si mira a la derecha, -1 si mira a la izquierda
        rb.velocity = new Vector2(featherspeed * direction, 0);


    }
    #endregion

}
