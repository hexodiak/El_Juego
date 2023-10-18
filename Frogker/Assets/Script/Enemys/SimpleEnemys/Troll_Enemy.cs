using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll_Enemy : MonoBehaviour
{
    #region Variables
    //Variables de unity
    PlayerStats player;
    
    //Variables de script
    public int enemyDamage = 3;
    public int maxHealth = 50;
    int currentHealth;

    #endregion



    #region Damage Player
    private void OnCollisionEnter2D(Collision2D collision)//cuando choca con un enemigo el personaje se le baja vida
    {
        if (collision.gameObject.tag == "Player")
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            player.TakeDamagePlayer(enemyDamage);
            Debug.Log("Golpea a "+collision.gameObject.name + enemyDamage);
        }

    }

    #endregion

    #region Damage to enemy
    void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(int damage)
    {

        currentHealth -= damage;

        //Hurt animation
        //animator.SetTrigger("nombre de animacion");

        if (currentHealth <= 0)
        {
            Die();
        }
        Debug.Log("Golpe a enemigo VIDA  "+currentHealth);
    }

    void Die()
    {

        //Die animation
        //animator.SetBool("animacion muerte", true);

        //Disable enemy
        //GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject);
        this.enabled = false;

        Debug.Log("Muerto");
    }


    #endregion
}
