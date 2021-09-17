using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private LeaderboardHandling leaderboardHandler;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private Text finalScoreDisplay1;
    [SerializeField] private GameObject viewLeaderboardButton1;

    [SerializeField] private GameObject losePanel;
    [SerializeField] private Text finalScoreDisplay2;
    [SerializeField] private GameObject viewLeaderboardButton2;


    public void OnPlayerWin()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            leaderboardHandler.SubmitScore();
        }
        else
        {
            viewLeaderboardButton1.SetActive(false);
        }

        winPanel.SetActive(true);
        if (finalScoreDisplay1.gameObject.activeSelf) finalScoreDisplay1.text = "SCORE: " + Score.totalScore.ToString();
    }

    public void OnPlayerLose()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            leaderboardHandler.SubmitScore();
        }
        else
        {
            viewLeaderboardButton2.SetActive(false);
        }
        losePanel.SetActive(true);
        finalScoreDisplay2.text = "SCORE: " + Score.totalScore.ToString();
    }

    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}