using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject panelSettings;
    [SerializeField] private GameObject mainMenu;
    public void PlayGame()
    {
        SceneManager.LoadScene("StartOpening");
    }
    public void SettingsGame()
    {
        panelSettings.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void BackSettingsMenu()
    {
        panelSettings.SetActive(false);
        mainMenu.SetActive(true);
    }
    // private void Update() {
    //     musicManager.SetVolume(sliderVolumeMusic.value);
    // }
    public void QuitGame()
    {
        Application.Quit();
        
    }
}
