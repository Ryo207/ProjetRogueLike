using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_Menu_Manager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject creditsMenu;
    public AudioMixer mainVolume;
    Resolution[] resolution;
    public Dropdown resolutionDropDown;
    
    // Start is called before the first frame update
    void Start()
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

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void OptionsButton()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void CreditsButton()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void MainVolume(float volume)
    {
        mainVolume.SetFloat("MainVolume", volume);
    }

    public void ReturnToMenu()
    {
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolutions = resolution[resolutionIndex];
        Screen.SetResolution(resolutions.width, resolutions.height, Screen.fullScreen);
    }

    public void ReturnToOptons()
    {
        creditsMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

}
