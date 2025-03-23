using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public GameObject mainMenu, completionScreen, leaderboardScreen, gameplayScreen;

    public void OnPlayClick()
    {
        mainMenu.SetActive(false);
    }

    public void loadMenu()
    {
        mainMenu.SetActive(true);
    }


}
