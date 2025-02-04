using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    #region Variables
    public Animator animator;
    Vector3 temp;
    int damage = 5;
    #endregion

    #region Start and Update method

    private void Start()
    {
        //animator.SetTrigger("");
        //StartCoroutine(WaitAndDestroy(2.0f));
    }

    private void Update()
    {
        ///temp = transform.localScale;
        //temp.y *= Time.deltaTime;
        //transform.localScale = temp;
        StartCoroutine(WaitAndDestroy(1.0f));
    }

    #endregion

    #region CollisionEnter detection and wait seconds method
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStats player = gameObject.GetComponent<PlayerStats>();
        if (collision.transform.name == "Player")
        {
            player.TakeDamagePlayer(damage);
        }
        //if (collision.gameObject.layer == 6)//touches wall
        //{
            //Destroy(gameObject);
        //}


    }

    IEnumerator WaitAndDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
        //animator.SetTrigger("Idle");
    }

    #endregion
}
