using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LonnieMovement : StateMachineBehaviour
{

    //Idle

    Transform SpawnPoint1;
    Transform SpawnPoint2;
    Transform SpawnPoint3;
    Transform point;
       

    Rigidbody2D rb;
    private float speed = 10f;
    private int num;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SpawnPoint1 = GameObject.FindGameObjectWithTag("SpawnPoint1").transform;
        SpawnPoint2 = GameObject.FindGameObjectWithTag("SpawnPoint2").transform;
        SpawnPoint3 = GameObject.FindGameObjectWithTag("SpawnPoint3").transform;
        rb = animator.GetComponent<Rigidbody2D>();

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
        animator.ResetTrigger("Idle");
    }

    
}
