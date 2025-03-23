using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class Choices : MonoBehaviour
{
    public EmailUIManager emailUIManager;

    private int correctChoices = 0;
    private int incorrectChoices = 0;
    private int totalChoices = 0;

    [SerializeField]
    public List<Button> buttons;

    public void Start()
    {
        correctChoices = 0;
        incorrectChoices = 0;

        SetButtons(true);
       
    }
    public void SpamOnClick()
    {
        EvaluateChoice(true);
    }
    public void NotSpamOnClick()
    {
        EvaluateChoice(false);
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
        }

        SetButtons(false); // disable after choice selected

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


}
