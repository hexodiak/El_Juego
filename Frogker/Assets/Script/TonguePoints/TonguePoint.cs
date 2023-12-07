using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonguePoint : MonoBehaviour
{
    public Transform tonguePoint;
    public Rigidbody2D rb;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Vector2.Distance(tonguePoint.position, tonguePoint.position) < 3) { 
            //Debug
        }
    }


    void OnDrawGizmosSelected()
    {

        if (tonguePoint == null)
            return;

        Gizmos.DrawWireSphere(tonguePoint.position, 3);
    }
}
