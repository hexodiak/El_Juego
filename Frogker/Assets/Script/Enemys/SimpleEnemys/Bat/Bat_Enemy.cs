using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_Enemy : MonoBehaviour
{

    //Variables unity


    //Variables script
    public Rigidbody2D rb;


    void Start()
    {
        
    }

    
    void Update()
    {
        rb.velocity = new Vector2(6.0f, 0f);
        
    }
    
}
