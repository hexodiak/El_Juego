using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LonnieMovement : StateMachineBehaviour
{

    //Run

    Transform SpawnPoint1;
    Transform SpawnPoint2;
    Transform SpawnPoint3;
    Transform point;
    EnemyBasic enemyBasic;   

    Rigidbody2D rb;
    Lonnie lonnie;
    private float speed = 10f;
    private int num;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        rb = animator.GetComponent<Rigidbody2D>();
        enemyBasic = animator.GetComponent<EnemyBasic>();
        lonnie = animator.GetComponent<Lonnie>();
        SpawnPoint1 = lonnie.Point1;
        SpawnPoint2 = lonnie.Point2;
        SpawnPoint3 = lonnie.Point3;
        

        num = Random.Range(0, 4);

        if (num == 0)
        {

            point = SpawnPoint1;
        }
        if (num == 1)
        {

            point = SpawnPoint1;
        }
        if (num == 2)
        {
            point = SpawnPoint2;
        }
        if (num == 3)
        {
            point = SpawnPoint3;
        }

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyBasic.LookAtPlayer();
        rb.gravityScale = 0;
        rb.position = Vector3.MoveTowards(rb.position, point.position, speed * Time.deltaTime);
        

        if (rb.position.x == point.position.x)//condicion para empezar la primera parte del ataque
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Run");
    }

    
}
