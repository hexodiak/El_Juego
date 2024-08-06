using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    #region Variables
    [Header("Menu setteo")]
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _climbMenu;
    [SerializeField] private GameObject _optionsMenu;
    [SerializeField] private GameObject _extrasMenu;


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
    }

    #endregion

    #region MainMenu interaction

    private void Menu() 
    { 
        _climbMenu.SetActive(false);
        _optionsMenu.SetActive(false);
        _extrasMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }

    public void Climb() 
    {
        _mainMenu.SetActive(false);
        _climbMenu.SetActive(true);
    }

    public void Options()
    {
        _mainMenu.SetActive(false);
        _optionsMenu.SetActive(true);
    }

    public void Extras()
    {
        _mainMenu.SetActive(false);
        _extrasMenu.SetActive(true);
    }



    #endregion
}
