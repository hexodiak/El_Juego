using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AudioButton : MonoBehaviour, ISelectHandler
{
    public GameObject panelOpciones; // Panel u opciones adicionales para este botón

    // Método que se llama cuando el botón es seleccionado
    public void OnSelect(BaseEventData eventData)
    {
        panelOpciones.SetActive(true); // Mostrar opciones adicionales
        Debug.Log(gameObject.name + " seleccionado.");
    }

    // Método que se llama cuando el botón pierde la selección
    
}
