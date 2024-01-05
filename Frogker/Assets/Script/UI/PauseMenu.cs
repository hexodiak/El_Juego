using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//scenes

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuCanvasGO;
    [SerializeField] private GameObject _settingsCanvasGO;

    private bool isPaused;
    private void Start()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsCanvasGO.SetActive(false);
    }

    void Update()
    {
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

        CloseMenus();
    }

    private void CloseMenus()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsCanvasGO.SetActive(false);
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        OpenMainMenu();
    }
    private void OpenMainMenu() 
    {
        _mainMenuCanvasGO.SetActive(true);
        _settingsCanvasGO.SetActive(false);
    }
    #endregion

    public void Options()
    {

    }

    public void GoToMenu()
    {
        
    }

}
