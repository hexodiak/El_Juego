using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;//scenes

public class MainMenu : MonoBehaviour
{
    #region Variables
    [Header("Menu principal")]
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _climbMenu;
    [SerializeField] private GameObject _optionsMenu;
    [SerializeField] private GameObject _extrasMenu;

    [Header("Menu opciones")]
    [SerializeField] private GameObject _audioMenu;
    [SerializeField] private GameObject _videoMenu;
    [SerializeField] private GameObject _controlsMenu;
    [SerializeField] private GameObject _definirMenu;

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

        //if (EventSystem.current.currentSelectedGameObject == _audioMenu) _audioMenu.SetActive(true);
        if (EventSystem.current.currentSelectedGameObject == _videoMenu) _videoMenu.SetActive(true);
        if (EventSystem.current.currentSelectedGameObject == _controlsMenu) _controlsMenu.SetActive(true);
    }
    private void Start()
    {
        Menu();
        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }

    #endregion

    #region MainMenu interaction

    private void Menu() 
    { 
        //menu principal
        _climbMenu.SetActive(false);
        _optionsMenu.SetActive(false);
        _extrasMenu.SetActive(false);

        //menu de opciones
        _audioMenu.SetActive(false);
        _videoMenu.SetActive(false);
        _controlsMenu.SetActive(false);
        _definirMenu.SetActive(false);


        _mainMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }

    private void Climb() 
    {
        _mainMenu.SetActive(false);
        _climbMenu.SetActive(true);

        SceneManager.LoadScene("Main");
    }

    private void Options()
    {
        _mainMenu.SetActive(false);
        _optionsMenu.SetActive(true);
        _audioMenu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(_optionsMenuFirst);

    }

    private void Extras()
    {
        _mainMenu.SetActive(false);
        _extrasMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }


    #endregion


    #region Settings Interaction





    #endregion
}
