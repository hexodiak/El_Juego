using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beak_Movement : StateMachineBehaviour
{

    Rigidbody2D rb;
    EnemyBasic enemyBasic;
    Lonnie lonnie;
    Transform startSecondAttackPositionBM;

    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        lonnie = animator.GetComponent<Lonnie>();
        enemyBasic = animator.GetComponent<EnemyBasic>();
        startSecondAttackPositionBM = lonnie.startSecondAttackPosition1;


    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        rb.position = Vector3.MoveTowards(rb.position, startSecondAttackPositionBM.position, 9f * Time.deltaTime);

        if (rb.position.x == startSecondAttackPositionBM.position.x)//condicion para empezar la primera parte del ataque
        {
            
            animator.SetTrigger("BeakSecondAttack");
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        
    }

}
