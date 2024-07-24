using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private bool isPaused;
    [SerializeField] private GameObject panelPauseMenu;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                isPaused = false;
                Time.timeScale = 1;
                panelPauseMenu.SetActive(false);
            }
            else
            {
                isPaused = true;
                Time.timeScale = 0;
                panelPauseMenu.SetActive(true);
            }
        }
    }
    public void ButtonMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
