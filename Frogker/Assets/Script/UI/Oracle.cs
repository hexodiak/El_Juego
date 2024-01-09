using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oracle : MonoBehaviour
{
    [Header("Variables gameobject panel textos")]
    [SerializeField] private GameObject dialogoOracle;
    

    void Start()
    {
        dialogoOracle.SetActive(false);
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialogoOracle.SetActive(true);
        }
    }
}
