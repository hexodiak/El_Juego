using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beak_Movement : StateMachineBehaviour
{

    Rigidbody2D rb;
    EnemyBasic enemyBasic;
    Lonnie lonnie;
    Transform beakPosition;

    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        lonnie = animator.GetComponent<Lonnie>();
        enemyBasic = animator.GetComponent<EnemyBasic>();
        beakPosition = lonnie.beakPoint; 


    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        rb.position = Vector3.MoveTowards(rb.position, beakPosition.position, 9f * Time.deltaTime);

        if (rb.position.x == beakPosition.position.x)//condicion para empezar la primera parte del ataque
        {
            enemyBasic.LookAtPlayer();
            animator.SetTrigger("BeakSecondAttack");
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Beak");
        
    }

}
