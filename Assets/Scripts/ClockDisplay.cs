using UnityEngine;
using TMPro;
using System;

public class ClockDisplay : MonoBehaviour
{
    public TextMeshProUGUI clockText;

    void Update()
    {
        DateTime now = DateTime.Now;
        clockText.text = now.ToString("dddd, MMMM d yyyy HH:mm");
    }
}