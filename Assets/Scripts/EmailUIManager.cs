using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class EmailUIManager : MonoBehaviour
{
    public TextMeshProUGUI senderText;
    public TextMeshProUGUI subjectText;
    public TextMeshProUGUI bodyText;
    public Email currentEmail;
    public Button currentEmailButton;
    public Image profilePicture;
    public Choices choices;
    [SerializeField]
    private EmailGenerator emailGenerator;
    public List<Email> emails;
    public List<Button> emailbgs;
    public List<TextMeshProUGUI> senderTexts, subjectTexts;
    public List<Image> profileImages;
    public RectTransform emailListPanel;
    float emailHeight = 82.91f;

    private void Start()
    {
        UnHighlightAllEmails();
        DisplayEmailList();
        ShowFirstEmail();
    }

    public void DisplayEmailList()
    {
        emails = emailGenerator.GetEmailQueue();
        Debug.Log("length of emails: " + emails.Count);

        for (int i = 0; i < emails.Count && i < senderTexts.Count && i < subjectTexts.Count; i++)
        {
            senderTexts[i].text = emails[i].Sender;
            subjectTexts[i].text = emails[i].Title;
            profileImages[i].sprite = emails[i].ProfilePicture;
        }
    }

    public void ShowFirstEmail()
    {
        DisplayEmail(0);
    }

    public void ChangeEmail()
    {
       choices.SetButtons(true);
        currentEmailButton.gameObject.SetActive(false);
        Vector2 size = emailListPanel.sizeDelta;
        size.y -= emailHeight;
        emailListPanel.sizeDelta = size;
        GameObject clickedObject = EventSystem.current.currentSelectedGameObject;
        if (clickedObject == null)
        {
            Debug.LogError("No UI object was clicked!");
            return;
        }
        string objectName = clickedObject.name;
        Debug.Log("Game Object Clicked: " + objectName);
        currentEmailButton = clickedObject.GetComponent<Button>();
        char lastCharacter = objectName[objectName.Length - 1];
        int number = 0;
        if (char.IsDigit(lastCharacter))
        {
            number = lastCharacter - '0';
        }
        else
        {
            Debug.Log("Game Object : " + gameObject.name);
            Debug.LogError($"Last character '{lastCharacter}' is not a number!");
        }

        DisplayEmail(number);

    }
    public void DisplayEmail(int emailNo)
    {
        Debug.Log("Generating Email");
        Email email = emailGenerator.GetEmail(emailNo);
        if (email == null) return; 

        senderText.text = $"From: {email.Sender}";
        subjectText.text = $"Subject: {email.Title}";
        bodyText.text = email.Body;
        currentEmail = email;
        currentEmailButton = emailbgs[emailNo];

        email.Read = true;

        if (email.ProfilePicture != null)
        {
            profilePicture.sprite = email.ProfilePicture;
            
        }

        HighlightCurrentEmail(email.Title);
    }

    public void HighlightCurrentEmail(string emailTitle)
    {
        UnHighlightAllEmails();

        for (int i = 0; i < subjectTexts.Count; i++)
        {
            if (subjectTexts[i].text == emailTitle)
            {
                emailbgs[i].GetComponent<Image>().color = Color.gray;
                break;
            }
        }
    }
    public void UnHighlightAllEmails()
    {
        Color unhighlightColor;
        if (ColorUtility.TryParseHtmlString("#28271E", out unhighlightColor))
        {
            foreach (Button emailbg in emailbgs)
            {
                emailbg.GetComponent<Image>().color = unhighlightColor;
            }
        }
        else
        {
            Debug.LogError("Invalid hex color for unhighlighted state. Using Color.black");
            foreach (Button emailbg in emailbgs)
            {
                emailbg.GetComponent<Image>().color = Color.black;
            }
        }
    }


    public Email GetCurrentEmail()
    {
        return currentEmail;
    }
}
