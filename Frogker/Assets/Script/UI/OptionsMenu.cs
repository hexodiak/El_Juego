using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsMenu : MonoBehaviour
{
    [Header("Opciones audio")]
    [SerializeField] private GameObject _audioOptions;
    [SerializeField] private GameObject _audioOptionsFirst;


    //Metodo para activar las opciones de audio
    private void Options()
    {
        _audioOptions.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_audioOptionsFirst);

    }
}
