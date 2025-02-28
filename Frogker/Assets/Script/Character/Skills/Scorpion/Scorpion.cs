using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorpion : MonoBehaviour
{
    public GameObject attackPrefab; // Prefab
    float attackOffset = 5f; // Distancia delante del personaje

    public int damage = 5;
    public float lifetime = 3f; // Destruir el proyectil después de 3 segundos

    void Start()
    {
        //Destroy(attackPrefab, lifetime);
    }

    public void Attack()
    {
        // Determinar la dirección del personaje
        float direction = Mathf.Sign(transform.localScale.x); // 1 si mira a la derecha, -1 si mira a la izquierda
        
        // Calcular la posición donde se creará el ataque (basado en la posición del personaje)
        Vector2 spawnPosition = new Vector2(transform.position.x + attackOffset * direction, transform.position.y);

        // Instanciar el ataque en la nueva posición
        Instantiate(attackPrefab, spawnPosition, Quaternion.identity);
    }



}
