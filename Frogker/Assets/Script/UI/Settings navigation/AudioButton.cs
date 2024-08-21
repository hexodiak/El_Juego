using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AudioButton : MonoBehaviour, ISelectHandler
{
    public GameObject panelOpciones; // Panel u opciones adicionales para este bot�n

    // M�todo que se llama cuando el bot�n es seleccionado
    public void OnSelect(BaseEventData eventData)
    {
        panelOpciones.SetActive(true); // Mostrar opciones adicionales
        Debug.Log(gameObject.name + " seleccionado.");
    }

    // M�todo que se llama cuando el bot�n pierde la selecci�n
    
}
