using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsMenu : MonoBehaviour
{
    [Header("Gameobject central del menu")]
    [SerializeField] private GameObject _optionsMenu;

    [Header("Opciones de menu")]
    [SerializeField] private GameObject _audioOptionsMenu;
    [SerializeField] private GameObject _videoOptionsMenu;
    //[SerializeField] private GameObject _controlsOptionsMenu;
    

    [Header("Options to scroll")]
    [SerializeField] private GameObject _audioOptionsFirst;
    [SerializeField] private GameObject _videoOptionsFirst;
    //[SerializeField] private GameObject _controlsOptionsFirst;
    [SerializeField] private GameObject _optionsMenuFirst;


    #region Audio options
    public void audioOptionsMenu()
    {
        _optionsMenu.SetActive(false);
        _audioOptionsMenu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(_audioOptionsFirst);

    }
    #endregion

    #region Video options
    public void videoOptionsMenu()
    {
        _optionsMenu.SetActive(false);
        _videoOptionsMenu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(_videoOptionsFirst);

    }

    #endregion

    #region Back Button
    public void backButton()
    {
        _audioOptionsMenu.SetActive(false);
        _videoOptionsMenu.SetActive(false);
        //_controlsOptionsMenu.SetActive(false);
        _optionsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(_optionsMenuFirst);

    }

    #endregion


    }
