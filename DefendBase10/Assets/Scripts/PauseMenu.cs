using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public Toggle pause;
    public GameObject Canvas;
     
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        pause.interactable = true;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        pause.interactable = false;
        
    }
    public void LoadMenu()
    {
        Time.timeScale = 0f;
        EnableCanvas();
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("Title");
    }
    void EnableCanvas()
    {
        Canvas.SetActive(true);
    }
}
