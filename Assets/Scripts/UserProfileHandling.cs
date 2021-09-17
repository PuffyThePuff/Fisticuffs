using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;
using UnityEngine.UI;

public class UserProfileHandling : MonoBehaviour
{
    [SerializeField] private GameObject signInPanel;
    [SerializeField] private GameObject registerPanel;
    [SerializeField] private GameObject editPanel;
    [SerializeField] private GameObject mainProfilePanel;

    [SerializeField] private InputField getUserIDField;

    [SerializeField] private InputField createNameField;
    [SerializeField] private InputField createNicknameField;
    [SerializeField] private InputField createEmailField;
    [SerializeField] private InputField createContactField;

    [SerializeField] private InputField editUserIDField;
    [SerializeField] private InputField editNameField;
    [SerializeField] private InputField editNicknameField;
    [SerializeField] private InputField editEmailField;
    [SerializeField] private InputField editContactField;

    [SerializeField] private Text nameDisplay;
    [SerializeField] private Text nicknameDisplay;
    [SerializeField] private Text emailDisplay;
    [SerializeField] private Text contactDisplay;

    public static string currentName = "Guest User";
    public static string currentNickname = "Guest";
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

            nameDisplay.text = "NAME: " + currentName;
            nicknameDisplay.text = "NICKNAME: " + currentNickname;
            emailDisplay.text = "EMAIL: " + currentEmail;
            contactDisplay.text = "CONTACT: " + currentContact;
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
        StartCoroutine(PostPlayer(createNicknameField.text, createNameField.text, createEmailField.text, createContactField.text));
        CloseRegisterPanel();
    }

    public void EditName()
    {
        StartCoroutine(PutPlayer(editUserIDField.text, "name", editNameField.text));
    }

    public void EditNickname()
    {
        StartCoroutine(PutPlayer(editUserIDField.text, "nickname", editNicknameField.text));
    }

    public void EditEmail()
    {
        StartCoroutine(PutPlayer(editUserIDField.text, "email", editEmailField.text));
    }

    public void EditContact()
    {
        StartCoroutine(PutPlayer(editUserIDField.text, "contact", editContactField.text));
    }

    public void SignInPlayer()
    {
        StartCoroutine(GetPlayer(getUserIDField.text));
    }

    public void OpenSignInPanel()
    {
        mainProfilePanel.SetActive(false);
        signInPanel.SetActive(true);
    }

    public void OpenRegisterPanel()
    {
        mainProfilePanel.SetActive(false);
        registerPanel.SetActive(true);
    }

    public void OpenEditPanel()
    {
        mainProfilePanel.SetActive(false);
        editPanel.SetActive(true);
    }

    public void CloseSignInPanel()
    {
        mainProfilePanel.SetActive(true);
        signInPanel.SetActive(false);
    }

    public void CloseRegisterPanel()
    {
        mainProfilePanel.SetActive(true);
        registerPanel.SetActive(false);
    }

    public void CloseEditPanel()
    {
        mainProfilePanel.SetActive(true);
        editPanel.SetActive(false);
    }
}