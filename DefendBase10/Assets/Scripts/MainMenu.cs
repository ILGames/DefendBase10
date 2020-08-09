using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject PauseMenuUI;
    public Toggle pause;

    public void PlayGame()
    {
        Time.timeScale = 1f;
        MainMenuUI.SetActive(false);
        PauseMenuUI.SetActive(false);
        pause.interactable = true;
    }
    public void QuitGame()
    {
        //Debug.Log ("QUIT")
        Application.Quit();
    }

}
