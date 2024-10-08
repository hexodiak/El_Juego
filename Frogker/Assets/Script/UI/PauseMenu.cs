using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//scenes
using UnityEngine.EventSystems;//para hacer el scroll de los gameobjets botones del menu y pausa

public class PauseMenu : MonoBehaviour
{
    #region Variables
    [Header("Menu controls")]
    [SerializeField] private GameObject _mainMenuCanvasGO;
    [SerializeField] private GameObject _settingsCanvasGO;

    [Header("Player deactivation for pausing")]
    [SerializeField] private Playermovement playermovement;
    [SerializeField] private PlayerCombat playercombat;

    [Header("Select options to scroll")]
    [SerializeField] private GameObject _mainMenuFirst;
    [SerializeField] private GameObject _settingsMenuFirst;

    private bool isPaused;


    #endregion

    private void Start()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsCanvasGO.SetActive(false);
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false) Pause();
        //if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true && _mainMenuCanvasGO == true) Resume();

        if (InputManager.instance.MenuOpenCloseInput)
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    #region Pause and resume methods
    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;

        //activar personaje al quitar la pausa
        playermovement.enabled = true;
        playercombat.enabled = true;

        CloseMenus();
    }

    private void CloseMenus()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        //desactivar personaje al poner pausa
        playermovement.enabled = false;
        playercombat.enabled = false;

        OpenMainMenu();
    }
    private void OpenMainMenu() 
    {
        _settingsCanvasGO.SetActive(false);
        _mainMenuCanvasGO.SetActive(true);
        

        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }
    #endregion

    public void Options()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsCanvasGO.SetActive(true);
        

        EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);
    }

    public void GoToMenu()
    {
        playermovement.enabled = true;
        playercombat.enabled = true;
        SceneManager.LoadScene("MainMenu");
    }

}
