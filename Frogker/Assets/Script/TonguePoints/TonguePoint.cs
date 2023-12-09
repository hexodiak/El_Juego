using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonguePoint : MonoBehaviour
{
    public Transform tonguePoint;
    public Transform topPoint;

    public LayerMask playerLayer;

    public int range = 2;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        Collider2D[] insideTonguePointArea = Physics2D.OverlapCircleAll(tonguePoint.position, range, playerLayer);

        //Damage then
        foreach (Collider2D inside in insideTonguePointArea)
        {
            Debug.Log("Dentro del rango esta: " + inside.name);
            //enemy.GetComponent<EnemyBasic>().TakeDamage(attackdamage);

            if (Input.GetButtonDown("Fire3"))
            {
                //float step = 140f * Time.deltaTime;
                inside.transform.position = Vector3.MoveTowards(inside.transform.position, topPoint.position, 1.9f);
            }
        }
    }


    void OnDrawGizmosSelected()
    {

        if (tonguePoint == null)
            return;

        Gizmos.DrawWireSphere(tonguePoint.position, range);
    }
}
