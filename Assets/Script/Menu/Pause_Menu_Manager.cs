using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_Menu_Manager : MonoBehaviour
{
    public YT_PCAnimationHandler animHandler;
    public PlayerShoot shoootingscript;
    public GameObject pauseMenu;
    public GameObject optionMenu;
    public AudioMixer mainVolume;
    bool freezeTime;
    Resolution[] resolution;
    public Dropdown resolutionDropDown;

    // Start is called before the first frame update
    void Start()
    {
        SetResolution();

    }

    void Update()
    {
        ActivateMenu();
    }

    void SetResolution()
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

    void ActivateMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf ^ optionMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
                optionMenu.SetActive(false);
                Time.timeScale = 1;
                animHandler.enabled = true;
                shoootingscript.enabled = true;
            }

            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                animHandler.enabled = false;
                shoootingscript.enabled = false;
            }
        }
    }
    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        animHandler.enabled = true;
        shoootingscript.enabled = true;
        Time.timeScale = 1;
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void OptionsButton()
    {
        pauseMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void QuitToMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void MainVolume(float volume)
    {
        mainVolume.SetFloat("MainVolume", volume);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolutions = resolution[resolutionIndex];
        Screen.SetResolution(resolutions.width, resolutions.height, Screen.fullScreen);
    }
    
    public void QuitOptionsButton()
    {
        optionMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

}
