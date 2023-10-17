using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll_Enemy : MonoBehaviour
{
    #region Variables
    PlayerStats player;
    

    public int enemyDamage = 3;

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


        //Debug.Log(collision.gameObject.name+enemyDamage);
    }

    #endregion
}
