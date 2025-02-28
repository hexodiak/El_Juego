using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : MonoBehaviour
{
    #region Variables

    float speed = 10f;
    public Rigidbody2D rb;
    int damage = 5;
    Playermovement playermovement;
    GameObject vel;
    #endregion

    #region Start move and collison to hit enemy
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        EnemyBasic enemy = collision.GetComponent<EnemyBasic>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
    #endregion
}
