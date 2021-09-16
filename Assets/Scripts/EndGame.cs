using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private Text finalScoreDisplay;
    [SerializeField] private GameObject losePanel;

    public void OnPlayerWin()
    {
        winPanel.SetActive(true);
        finalScoreDisplay.text = Score.totalScore.ToString();
    }

    public void OnPlayerLose()
    {
        losePanel.SetActive(true);
    }

    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}