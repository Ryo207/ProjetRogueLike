using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Menu_Manager : MonoBehaviour
{
    public PlayerController playerController;
    public Bullet bullet;
    public GameObject MenuPause;
    public GameObject MenuOptions;
    public GameObject Credits;
    public AudioMixer MainVolume;
    Resolution[] resolution;
    public Dropdown resolutionDropDown;
    private void Update()
    {
        StopController();
    }
    private void Start()
    {

        resolution = Screen.resolutions;
        resolutionDropDown.ClearOptions();
            
        List<string> options = new List<string>();

        int currentRosolutionIndex = 0;
        for (int i = 0; i < resolution.Length; i++)
        {
            string option = resolution[i].width + "x" + resolution[i].height;
            options.Add(option);

            if (resolution[i].width == Screen.currentResolution.width && resolution[i].height == Screen.currentResolution.height)
            {
                currentRosolutionIndex = i;

            }
        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentRosolutionIndex;
        resolutionDropDown.RefreshShownValue();

    }

    void StopController()
    {
        if (playerController.stopTimePause == false)
        {
            bullet.enabled = true;
        }
    }

    public void playGame()
    {
        SceneManager.LoadScene(1);
        playerController.stopTimePause = false;
        bullet.enabled = true;

    }

    public void quitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
        playerController.stopTimePause = false;
        bullet.enabled = true;
    }

    public void playRestart()
    {
        SceneManager.LoadScene(1);
        playerController.stopTimePause = false;
        bullet.enabled = true;

    }
    public void Resume()
    {
        MenuPause.SetActive(false);
        MenuOptions.SetActive(false);
        playerController.stopTimePause = false;
        bullet.enabled = true;
        Time.timeScale = 1;
    }

    public void PlayOptions()
    {
        MenuPause.SetActive(false);
        MenuOptions.SetActive(true);
    }

    public void QuitOptions()
    {
        MenuOptions.SetActive(false);
        MenuPause.SetActive(true);
    }

    public void OptionsMainVolume(float volume)
    {
        MainVolume.SetFloat("MainVolume",volume);

    }
    public void PlayCredits()
    {
        MenuPause.SetActive(false);
        MenuOptions.SetActive(false);
        Credits.SetActive(true);
    }

    public void QuitCreditsToOptions()
    {
        Credits.SetActive(false);
        MenuOptions.SetActive(true);
    }

    public void QuitCreditToMenu()
    {
        Credits.SetActive(false);
        MenuPause.SetActive(true);
    }
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolutions = resolution[resolutionIndex];
        Screen.SetResolution(resolutions.width, resolutions.height, Screen.fullScreen);
    }

    public void PlayMainMenu()
    {
        SceneManager.LoadScene(0);
        playerController.stopTimePause = false;
        bullet.enabled = true;
    }
}
