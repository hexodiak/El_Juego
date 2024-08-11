using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    #region Variables
    [Header("Menu setteo")]
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _climbMenu;
    [SerializeField] private GameObject _optionsMenu;
    [SerializeField] private GameObject _extrasMenu;

    [Header("Options to scroll")]
    [SerializeField] private GameObject _mainMenuFirst;//Main menu selects climb as it first option
    [SerializeField] private GameObject _optionsMenuFirst;//In setting menu selects sound as it first option


    #endregion

    #region Start-Update
    void Update()
    {
        //Utilizar la tecla escape en el menu
        if (Input.GetKeyDown(KeyCode.Escape) && _climbMenu == true) Menu();
        if (Input.GetKeyDown(KeyCode.Escape) && _optionsMenu == true) Menu();
        if (Input.GetKeyDown(KeyCode.Escape) && _extrasMenu == true) Menu();

    }
    private void Start()
    {
        _mainMenu.SetActive(true);
        _climbMenu.SetActive(false);
        _optionsMenu.SetActive(false);
        _extrasMenu.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }

    #endregion

    #region MainMenu interaction

    private void Menu() 
    { 
        _climbMenu.SetActive(false);
        _optionsMenu.SetActive(false);
        _extrasMenu.SetActive(false);
        _mainMenu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }

    private void Climb() 
    {
        _mainMenu.SetActive(false);
        _climbMenu.SetActive(true);
    }

    private void Options()
    {
        _mainMenu.SetActive(false);
        _optionsMenu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(_optionsMenuFirst);

    }

    private void Extras()
    {
        _mainMenu.SetActive(false);
        _extrasMenu.SetActive(true);
    }



    #endregion
}
