using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EmailUIManager : MonoBehaviour
{
    public TextMeshProUGUI senderText;
    public TextMeshProUGUI subjectText;
    public TextMeshProUGUI bodyText;
    private Email currentEmail;
    public Image profilePicture; // UI Image for profile pic
    [SerializeField]
    private EmailGenerator emailGenerator;

    private void Start()
    {
        if (emailGenerator != null)
        {
            DisplayRandomEmail();
        }
        else
        {
            Debug.LogError("EmailGenerator not found in scene!");
        }
    }

    public void DisplayRandomEmail()
    {
        Debug.Log("Generating Email");
        Email email = emailGenerator.GenerateRandomEmail();
        if (email == null) return; 


        senderText.text = $"From: {email.Sender}";
        subjectText.text = $"Subject: {email.Title}";
        bodyText.text = email.Body;
        currentEmail = email;

        if (email.ProfilePicture != null)
        {
            profilePicture.sprite = email.ProfilePicture;
        }
    }

    public Email GetCurrentEmail()
    {
        return currentEmail;
    }
}
