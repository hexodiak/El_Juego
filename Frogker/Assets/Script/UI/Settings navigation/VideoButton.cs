using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VideoButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public GameObject panelOpciones; // Panel u opciones adicionales para este bot�n

    // M�todo que se llama cuando el bot�n es seleccionado
    public void OnSelect(BaseEventData eventData)
    {
        panelOpciones.SetActive(true); // Mostrar opciones adicionales
        Debug.Log(gameObject.name + " seleccionado.");
    }

    // M�todo que se llama cuando el bot�n pierde la selecci�n
    public void OnDeselect(BaseEventData eventData)
    {
        panelOpciones.SetActive(false); // Ocultar opciones adicionales
        Debug.Log(gameObject.name + " deseleccionado.");
    }
}
