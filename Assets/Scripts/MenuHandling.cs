using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandling : MonoBehaviour
{
    [SerializeField] public GameObject titleScreen;
    [SerializeField] public GameObject mainMenu;
    [SerializeField] public GameObject optionsMenu;

    public void OpenMainMenu()
    {
        this.mainMenu.SetActive(true);
        this.titleScreen.SetActive(false);
        this.optionsMenu.SetActive(false);
    }

    public void OpenOptionsMenu()
    {
        this.optionsMenu.SetActive(true);
        this.mainMenu.SetActive(false);
    }

    public void ReturnToTitleScreen()
    {
        this.titleScreen.SetActive(true);
        this.mainMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}