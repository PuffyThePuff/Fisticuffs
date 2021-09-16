using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;
using UnityEngine.UI;

public class UserProfileHandling : MonoBehaviour
{
    [SerializeField] private GameObject offlinePanel;
    [SerializeField] private GameObject onlinePanel;

    [SerializeField] private InputField nameCreateField;
    [SerializeField] private InputField nicknameCreateField;
    [SerializeField] private InputField emailCreateField;
    [SerializeField] private InputField contactCreateField;

    [SerializeField] private InputField userIDDisplayField;

    [SerializeField] private InputField userIDEditField;
    [SerializeField] private InputField nameEditField;
    [SerializeField] private InputField nicknameEditField;
    [SerializeField] private InputField emailEditField;
    [SerializeField] private InputField contactEditField;

    public static string currentName;
    public static string currentNickname;
    public static string currentEmail;
    public static string currentContact;

    public string BaseURL
    {
        get { return "https://my-user-scoreboard.herokuapp.com/api/"; }
    }

    public IEnumerator PostPlayer(string nickname, string name, string email, string contact)
    {
        Dictionary<string, string> playerParameters = new Dictionary<string, string>();
        playerParameters.Add("nickname", nickname);
        playerParameters.Add("name", name);
        playerParameters.Add("email", email);
        playerParameters.Add("contact", contact);
        string requestString = JsonConvert.SerializeObject(playerParameters);
        byte[] requestData = new UTF8Encoding().GetBytes(requestString);

        UnityWebRequest req = new UnityWebRequest(BaseURL + "players", "POST");
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

    public IEnumerator GetPlayer(string userID)
    {
        UnityWebRequest req = new UnityWebRequest(BaseURL + "players/" + userID, "GET");
        req.downloadHandler = new DownloadHandlerBuffer();

        yield return req.SendWebRequest();

        Debug.Log($"Response Code: {req.responseCode} ");
        if (string.IsNullOrEmpty(req.error))
        {
            Dictionary<string, string> player = JsonConvert.DeserializeObject<Dictionary<string, string>>(req.downloadHandler.text);

            currentName = player["name"];
            currentNickname = player["nickname"];
            currentEmail = player["email"];
            currentContact = player["contact"];
        }
        else Debug.LogError($"Error: {req.error}");
    }

    public IEnumerator PutPlayer(string userID, string parameter, string newValue)
    {
        Dictionary<string, string> playerParameters = new Dictionary<string, string>();
        playerParameters.Add(parameter, newValue);
        string requestString = JsonConvert.SerializeObject(playerParameters);
        byte[] requestData = new UTF8Encoding().GetBytes(requestString);

        UnityWebRequest req = new UnityWebRequest(BaseURL + "players/" + userID, "PUT");
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

    public void CreatePlayer()
    {
        StartCoroutine(PostPlayer(nicknameCreateField.text, nameCreateField.text, emailCreateField.text, contactCreateField.text));
    }
}