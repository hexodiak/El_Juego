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
    float counterNextMove;
    int nextSpawn;
    bool next;

    #endregion

    #region Start and Update to start attacks
    void Start()
    {
        next = true;
    }


    void Update()
    {
        counterNextMove += Time.deltaTime;
        if (counterNextMove >= 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawnOne.transform.position, speed * Time.deltaTime);
            
            nextSpawn = 0;
        }
        
    }

    #endregion

    #region Method of lines of attacks
    private void AttacksOrder()
    {
        next = false;
        nextSpawn = Random.Range(1, 3);

        if (nextSpawn == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawnOne.transform.position, speed * Time.deltaTime);
            counterNextMove = 0;
            nextSpawn = 0;
            next = true;
        }
        if (nextSpawn == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawnTwo.transform.position, speed * Time.deltaTime);
            counterNextMove = 0;
            nextSpawn = 0;
        }
        if (nextSpawn == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawnThree.transform.position, speed * Time.deltaTime);
            counterNextMove = 0;
            nextSpawn = 0;
        }
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
