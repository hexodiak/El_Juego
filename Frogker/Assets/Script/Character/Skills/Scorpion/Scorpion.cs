using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorpion : MonoBehaviour
{
    public GameObject attackPrefab; // Prefab
    float attackOffset = 5f; // Distancia delante del personaje

    public int damage = 5;
    public float lifetime = 3f; // Destruir el proyectil despu�s de 3 segundos

    void Start()
    {
        //Destroy(attackPrefab, lifetime);
    }

    public void Attack()
    {
        // Determinar la direcci�n del personaje
        float direction = Mathf.Sign(transform.localScale.x); // 1 si mira a la derecha, -1 si mira a la izquierda
        
        // Calcular la posici�n donde se crear� el ataque (basado en la posici�n del personaje)
        Vector2 spawnPosition = new Vector2(transform.position.x + attackOffset * direction, transform.position.y);

        // Instanciar el ataque en la nueva posici�n
        Instantiate(attackPrefab, spawnPosition, Quaternion.identity);
    }



}
