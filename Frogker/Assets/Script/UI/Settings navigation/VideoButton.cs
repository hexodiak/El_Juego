using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VideoButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public GameObject panelOpciones; // Panel u opciones adicionales para este botón

    // Método que se llama cuando el botón es seleccionado
    public void OnSelect(BaseEventData eventData)
    {
        panelOpciones.SetActive(true); // Mostrar opciones adicionales
        Debug.Log(gameObject.name + " seleccionado.");
    }

    // Método que se llama cuando el botón pierde la selección
    public void OnDeselect(BaseEventData eventData)
    {
        panelOpciones.SetActive(false); // Ocultar opciones adicionales
        Debug.Log(gameObject.name + " deseleccionado.");
    }
}
