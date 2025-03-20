using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class EmailUIManager : MonoBehaviour
{
    public TextMeshProUGUI senderText;
    public TextMeshProUGUI subjectText;
    public TextMeshProUGUI bodyText;
    public Email currentEmail;
    public Image profilePicture;
    [SerializeField]
    private EmailGenerator emailGenerator;
    public TextMeshProUGUI email1Sender, email1Subject, email2Sender, email2Subject, email3Sender, email3Subject, email4Sender, email4Subject, email5Sender, email5Subject;
    public Image email1bg, email2bg, email3bg, email4bg, email5bg;
    public List<Email> emails;

    private void Start()
    {
        UnHighlightAllEmails();
        DisplayEmailList();
        ShowFirstEmail();
    }

    public void DisplayEmailList() {
        emails = emailGenerator.GetEmailQueue();
        Debug.Log("length of emails: " + emails.Count);
        email1Sender.text = emails[0].Sender;
        email1Subject.text = emails[0].Title;
        email2Sender.text = emails[1].Sender;
        email2Subject.text = emails[1].Title;
        email3Sender.text = emails[2].Sender;
        email3Subject.text = emails[2].Title;
        email4Sender.text = emails[3].Sender;
        email4Subject.text = emails[3].Title;
        email5Sender.text = emails[4].Sender;
        email5Subject.text = emails[4].Title;
    }

    public void ShowFirstEmail()
    {
        DisplayEmail(1);
    }

    public void ChangeEmail()
    {
        string objectName = gameObject.name;
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
        switch (emailTitle)
        {
            case var title when title == email1Subject.text:
                email1bg.color = Color.gray;
                break;

            case var title when title == email2Subject.text:
                email2bg.color = Color.gray;
                break;

            case var title when title == email3Subject.text:
                email3bg.color = Color.gray;
                break;

            case var title when title == email4Subject.text:
                email4bg.color = Color.gray;
                break;

            case var title when title == email5Subject.text:
                email5bg.color = Color.gray;
                break;
        }
    }

    public void UnHighlightAllEmails()
    {
        email1bg.color = Color.black;
        email2bg.color = Color.black;
        email3bg.color = Color.black;
        email4bg.color = Color.black;
        email5bg.color = Color.black;
    }

    public Email GetCurrentEmail()
    {
        return currentEmail;
    }
}
