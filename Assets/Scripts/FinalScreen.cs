using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinalScreen : MonoBehaviour
{

    public TMP_InputField nameInput;
    public int finalScore;
    public Choices choices;
    public LeaderboardUI lb;
    public GameObject submit, showLB;
    public GameObject LeaderboardScreen;

    public void Start()
    {
        showLB.SetActive(false);
        LeaderboardScreen.SetActive(false);
    }

    public void OnSubmit()
    {
        finalScore = choices.GetCorrectChoices();
        lb.SubmitScore(nameInput.text, finalScore);
        submit.SetActive(false);
        showLB.SetActive(true);
    }

    public void ShowLB()
    {
        LeaderboardScreen.SetActive(true);
    }
}