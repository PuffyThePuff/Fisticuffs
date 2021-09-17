using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;
using UnityEngine.UI;

public class LeaderboardHandling : MonoBehaviour
{
    [SerializeField] private GameObject leaderboardPanel;
    [SerializeField] private Text[] scoreDisplayList;

    public string BaseURL
    {
        get { return "https://my-user-scoreboard.herokuapp.com/api/"; }
    }

    public IEnumerator PostScore(string username)
    {
        Dictionary<string, string> playerParameters = new Dictionary<string, string>();
        playerParameters.Add("group_num", "9");
        playerParameters.Add("user_name", username);
        playerParameters.Add("score", Score.totalScore.ToString());
        string requestString = JsonConvert.SerializeObject(playerParameters);
        byte[] requestData = new UTF8Encoding().GetBytes(requestString);

        UnityWebRequest req = new UnityWebRequest(BaseURL + "scores", "POST");
        req.SetRequestHeader("Content-Type", "application/json");
        req.uploadHandler = new UploadHandlerRaw(requestData);
        req.downloadHandler = new DownloadHandlerBuffer();

        yield return req.SendWebRequest();

        Debug.Log($"Response Code: {req.responseCode} ");
        if (!string.IsNullOrEmpty(req.error))
        {
            Debug.LogError($"Error: {req.error}");
        }
    }

    public IEnumerator GetScores()
    {
        UnityWebRequest req = new UnityWebRequest(BaseURL + "get_scores/9", "GET");
        req.downloadHandler = new DownloadHandlerBuffer();

        yield return req.SendWebRequest();

        Debug.Log($"Response Code: {req.responseCode} ");
        if (string.IsNullOrEmpty(req.error))
        {
            List<Dictionary<string, string>> playerList = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(req.downloadHandler.text);

            for (int i = 0; i < 3; i++)
            {
                scoreDisplayList[i].text = playerList[i]["user_name"] + " - " + playerList[i]["score"];
            }

            scoreDisplayList[3].text = "DCS" + " - " + Score.totalScore.ToString();
        }
        else Debug.LogError($"Error: {req.error}");
    }

    public void SubmitScore()
    {
        // StartCoroutine(PostScore(UserProfileHandling.currentNickname));
        StartCoroutine(PostScore("DCS"));
    }

    public void ViewLeaderboard()
    {
        StartCoroutine(GetScores());
        leaderboardPanel.SetActive(true);
    }
}