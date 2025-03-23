using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Choices : MonoBehaviour
{
    public EmailUIManager emailUIManager;

    private int correctChoices, incorrectChoices, totalChoices, numberOfChoices;


    [SerializeField]
    public List<Button> buttons;
    public TextMeshProUGUI emailMark, popupTitle, popupText, scoreText;
    public GameObject finalScreen, popup;

    public void Start()
    {
        finalScreen.SetActive(false);
        ClosePopup();
        correctChoices = 0;
        incorrectChoices = 0;
        totalChoices = 0;  
        numberOfChoices = 7;
        SetButtons(false);
       
    }
    public void SpamOnClick()
    {
        EvaluateChoice(true);
        emailMark.text = "Email marked as : SPAM";
    }
    public void NotSpamOnClick()
    {
        EvaluateChoice(false);
        emailMark.text = "Email marked as : SAFE";
    }

    public void EvaluateChoice(bool playerThinksSpam)
    {
        Email currentEmail = emailUIManager.GetCurrentEmail();
        if (currentEmail == null) return;

        totalChoices++;

        if (playerThinksSpam == currentEmail.Scam)
        {
            correctChoices++;
        }
        else
        {
            incorrectChoices++;
            if (currentEmail.Title == "Company Credit Card Expiry!") {
                Debug.Log("Starting Popup CR");
                ShowPopUp("Credit Charge Notification", "Your Company Card has been used to tranfer £19,208 to PRIVATE");
            }
            if (currentEmail.Title == "Congratulations! You’ve Won a £50 Gift Card!")
            {
                Debug.Log("Starting Popup CR");
                ShowPopUp("WARNING!", "Your device is INFECTED!");
            }
            if (currentEmail.Title == "Congratulations! You’ve Won a £50 Gift Card!")
            {
                Debug.Log("Starting Popup CR");
                ShowPopUp("WARNING!", "Your device is INFECTED!");
            }
            if (currentEmail.Title == "Meeting Reminder: Project Update")
            {
                Debug.Log("Starting Popup CR");
                ShowPopUp("Meeting added to Calender", "RE: Meeting Absence");
            }
        }

        SetButtons(false); // disable after choice selected
        currentEmail.Completed = true;

        if (totalChoices == numberOfChoices)
        {
            ShowFinalScreen();
        }

    }

    public void SetButtons(bool boobar)
    {
        Debug.Log("Setting buttons to : " + boobar);
        foreach (Button button in buttons)
        {
            Debug.Log("Disabling button: " + button.name);
            button.interactable = boobar;
        }
    }

    public void ShowPopUp(string title, string text)
    {
        StartCoroutine(PopUpRoutine(title, text));
    }

    private IEnumerator PopUpRoutine(string title, string text)
    {
        yield return new WaitForSeconds(5f); // wait before showing

        popup.SetActive(true);
        popupTitle.text = title;
        popupText.text = text;

        yield return new WaitForSeconds(10f); // wait before auto-closing

        if (popup.activeSelf)
        {
            ClosePopup();
        }
    }

    public void ClosePopup()
    {
        popup.SetActive(false);
    }

    public void ShowFinalScreen()
    {   
        finalScreen.SetActive(true);
        scoreText.text = correctChoices + "/" + totalChoices + " correct";
    }

    public int GetCorrectChoices()
    {
        return correctChoices;
    }
}
