using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{

    PlayerController playerController;
    public GameObject MenuPause;
    public GameObject MenuOptions;

    private void Start()
    {
        playerController = GameObject.Find("Perso").GetComponent<PlayerController>();

    }

    public void playGame()
    {
        SceneManager.LoadScene(0);

    }

    public void playCredits()
    {
        SceneManager.LoadScene(2);
    }

    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void playRestart()
    {
        SceneManager.LoadScene(0);

    }

    public void playOptions()
    {
        SceneManager.LoadScene(3);

    }
    public void Resume()
    {
        MenuPause.SetActive(false);
        playerController.stopTimePause = false;
        Time.timeScale = 1;
    }

    public void OptionsInGame()
    {
        StartCoroutine("OptionsInGame");

    }
    IEnumerator optionsingame()
        {
        MenuPause.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        MenuOptions.SetActive(true);
        playerController.stopTimePause = false;
        }



    public void PlayMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
