using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject Canvas;

    public GameObject[] otherCanvasStuff;
    private bool[] otherCanvasStuffStates;

    private void Start()
    {
        otherCanvasStuffStates = new bool[otherCanvasStuff.Length];
    }

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

        //show other canvas stuff
        GameObject thingy;
        for (int i = 0; i < otherCanvasStuff.Length; i++)
        {
            thingy = otherCanvasStuff[i];

            if (otherCanvasStuffStates[i])
            {
                thingy.SetActive(true);
            }

        }
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        //hide other canvas stuff
        GameObject thingy;
        for (int i = 0; i < otherCanvasStuff.Length; i++)
        {
            thingy = otherCanvasStuff[i];

            if (thingy.activeSelf)
            {
                otherCanvasStuffStates[i] = true;
                thingy.SetActive(false);
            }
            else
            {
                otherCanvasStuffStates[i] = false;
            }

        }
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
