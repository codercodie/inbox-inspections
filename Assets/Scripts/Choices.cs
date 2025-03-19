using UnityEngine;
using TMPro;

public class Choices : MonoBehaviour
{
    public EmailUIManager emailUIManager;

    private int correctChoices = 0;
    private int incorrectChoices = 0;
    private int totalChoices = 0;

    public TextMeshProUGUI correct;
    public TextMeshProUGUI incorrect;

    public void Start()
    {
        correctChoices = 0;
        incorrectChoices = 0;
        correct.text = "Correct: " + correctChoices;
        incorrect.text = "Incorrect: " + incorrectChoices;
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
            correct.text = "Correct: " + correctChoices;
        }
        else
        {
            incorrectChoices++;
            incorrect.text = "Incorrect: " + incorrectChoices;
        }

        Invoke(nameof(LoadNextEmail), 0.25f);
    }

    private void LoadNextEmail()
    {
        emailUIManager.DisplayRandomEmail();
    }

}
