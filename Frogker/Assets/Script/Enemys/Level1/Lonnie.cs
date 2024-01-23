using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lonnie : MonoBehaviour
{
    #region Variables
    [Header("Puntos de Spawn donde ira Lonnie")]
    [SerializeField] private GameObject spawnOne;
    [SerializeField] private GameObject spawnTwo;
    [SerializeField] private GameObject spawnThree;

    //Unity
    public Rigidbody2D rb;

    //seconds to wait
    [SerializeField] private float speed;
    float counterNextMove = 0f;
    int nextSpawn;
    bool next;
    private Vector2 velocity;

    public Transform player;
    #endregion

    #region Start and Update to start attacks
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }


    

    void Update()
    {
        
    }

    #endregion

    #region Method of lines of attacks
    public void AttacksOrder()
    {
        next = false;
        nextSpawn = Random.Range(1, 3);

        if (nextSpawn == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawnOne.transform.position, speed * Time.deltaTime);
            //counterNextMove = 0;
            nextSpawn = 0;
            next = true;
        }
        if (nextSpawn == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawnTwo.transform.position, speed * Time.deltaTime);
            //counterNextMove = 0;
            nextSpawn = 0;
        }
        if (nextSpawn == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawnThree.transform.position, speed * Time.deltaTime);
            //counterNextMove = 0;
            nextSpawn = 0;
        }
    }

    public void Follow()
    {
        rb.position = Vector3.MoveTowards(rb.position, player.position, speed * Time.deltaTime);
    }
        #endregion

        #region waiting seconds
        public IEnumerator waitSeconds()//Metodo para esperar segundos
    {
        Debug.Log("pasaron 3 segundos");
        yield return new WaitForSeconds(3);

    }

    #endregion
}
