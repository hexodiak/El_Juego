using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//scenes

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;
    

    //public bool inGame = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (GameIsPaused)
            {
                Resume();
            }else if (!GameIsPaused)
            {
                Pause();
            }
            
        }
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false); //se desactiva la escena
        Time.timeScale = 1f; //devuelve tiempo normal
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUi.SetActive(true); //se activa la escena
        Time.timeScale = 0f; //freezea tiempo
        GameIsPaused = true;
    }

    public void Options()
    {
        //SceneManager.LoadScene(2);
    }

    public void GoToMenu()
    {
        //Time.timeScale = 1f;
        //SceneManager.LoadScene(1);
    }

}
