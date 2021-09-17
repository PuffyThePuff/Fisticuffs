using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandling : MonoBehaviour
{
    [SerializeField] public GameObject titleScreen;
    [SerializeField] public GameObject optionsMenu;
    [SerializeField] public GameObject profileMenu;

    [SerializeField] private GameObject offlinePanel;

    public static int levelNumber = 1;

    public void OpenOptionsMenu()
    {
        this.optionsMenu.SetActive(true);
        this.titleScreen.SetActive(false);
    }

    public void OpenProfileMenu()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            this.profileMenu.SetActive(true);
            this.optionsMenu.SetActive(false);
        }
        else
        {
            offlinePanel.SetActive(true);
            this.optionsMenu.SetActive(false);
        }
    }

    public void ReturnToTitleScreen()
    {
        this.titleScreen.SetActive(true);
        this.optionsMenu.SetActive(false);
    }

    public void CloseOfflinePopup()
    {
        this.optionsMenu.SetActive(true);
        offlinePanel.SetActive(false);
    }

    public void ReturnToOptionsMenu()
    {
        this.optionsMenu.SetActive(true);
        this.profileMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("Level " + levelNumber.ToString());
    }
}