using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollMeleeDetector : MonoBehaviour
{
    //Variables
    Troll_Enemy troll;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            troll = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Troll_Enemy>();
            troll.MeleeAttack();
        }
    }
}
