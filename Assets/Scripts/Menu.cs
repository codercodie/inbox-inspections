using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public GameObject mainMenu;

    public void OnPlayClick()
    {
        mainMenu.SetActive(false);
    }


}
