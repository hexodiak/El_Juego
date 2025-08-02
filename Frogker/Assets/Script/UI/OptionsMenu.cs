using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsMenu : MonoBehaviour
{
    #region Variables
    [Header("Gameobject central del menu")]
    [SerializeField] private GameObject _optionsMenu;

    [Header("Opciones de menu")]
    [SerializeField] private GameObject _audioOptionsMenu;
    [SerializeField] private GameObject _videoOptionsMenu;
    [SerializeField] private GameObject _controlsOptionsMenu;
    [SerializeField] private GameObject _controlsOptionsMenuKeybindings;
    [SerializeField] private GameObject _controlsOptionsMenuGamepad;
    

    [Header("Options to scroll")]
    [SerializeField] private GameObject _audioOptionsFirst;
    [SerializeField] private GameObject _videoOptionsFirst;
    [SerializeField] private GameObject _controlsOptionsFirst;
    [SerializeField] private GameObject _controlsOptionsFirstKeybindings;
    [SerializeField] private GameObject _controlsOptionsFirstGamepad;
    [SerializeField] private GameObject _optionsMenuFirst;

    #endregion
    void Update()
    {
        //Utilizar la tecla escape en el options menu
        if (Input.GetKeyDown(KeyCode.Escape)) backButton();
        if (Input.GetKeyDown(KeyCode.Escape) && _videoOptionsMenu == true) backButton();
        //if (Input.GetKeyDown(KeyCode.Escape) && _controlsOptionsMenu == true) backButton();

    }

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

    #region Controls Menu
    public void controlsOptionsMenu() //abre el menu para escoger que editar de controles
    {
        _optionsMenu.SetActive(false);
        _controlsOptionsMenu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(_controlsOptionsFirst);

    }

    public void controlsOptionsMenuKeyBindings() //abre las opciones para editar el teclado
    {
        _controlsOptionsMenu.SetActive(false);
        _controlsOptionsMenuKeybindings.SetActive(true);

        EventSystem.current.SetSelectedGameObject(_controlsOptionsFirstKeybindings);

    }


    public void controlsOptionsMenuGamepad() // abre las opciones para editar el control o gamepad
    {
        _controlsOptionsMenu.SetActive(false);
        _controlsOptionsMenuGamepad.SetActive(true);

        EventSystem.current.SetSelectedGameObject(_controlsOptionsFirstGamepad);

    }
    #endregion


    #region Back Button
    public void backButton()
    {
        _audioOptionsMenu.SetActive(false);
        _videoOptionsMenu.SetActive(false);
        _controlsOptionsMenu.SetActive(false);
        _controlsOptionsMenuKeybindings.SetActive(false);
        _controlsOptionsMenuGamepad.SetActive(false);
        _optionsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(_optionsMenuFirst);

    }

    
    #endregion


}
