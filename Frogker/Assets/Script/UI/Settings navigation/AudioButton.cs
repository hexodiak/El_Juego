using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AudioButton : MonoBehaviour
{
    [Header("Menu opciones")]
    [SerializeField] private GameObject _audioOptions;
    [SerializeField] private GameObject _audioOptionsFirst;


    //Metodo para activar las opciones de audio
    private void Options()
    {
        _audioOptions.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_audioOptionsFirst);

    }

    

}
