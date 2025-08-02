using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;//scenes
using TMPro;

public class MainMenu : MonoBehaviour
{
    #region Variables
    [Header("Main menu")]
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _climbMenu;
    [SerializeField] private GameObject _optionsMenu;
    [SerializeField] private GameObject _extrasMenu;

    [Header("Options to scroll")]
    [SerializeField] private GameObject _mainMenuFirst;//Main menu selects climb as it first option
    [SerializeField] private GameObject _optionsMenuFirst;//In setting menu selects audio as it first option


    #endregion

    #region Start-Update
    void Update()
    {
        //Utilizar la tecla escape en el menu
        if (Input.GetKeyDown(KeyCode.Escape) && _climbMenu == true) Menu();
        if (Input.GetKeyDown(KeyCode.Escape) && _optionsMenu == true) Menu();
        if (Input.GetKeyDown(KeyCode.Escape) && _extrasMenu == true) Menu();
        //if (Input.GetKeyDown(KeyCode.Escape) && _audioOptionsMenu == true) optionsOut();

    }

    private void Start()
    {
        //Menu
        Menu();

        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);

    }

    #endregion

    #region MainMenu interaction

    public void Menu() 
    { 
        //menu principal
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

        SceneManager.LoadScene("Main");
    }

    private void Options()
    {
        _mainMenu.SetActive(false);
        //_mainMenu.GetComponent<MainMenu>().enabled=false;
        _optionsMenu.SetActive(true);
        

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


    

}
