using System;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    //edited ~10:30 pm friday by casey
    //simple placeholder script to close game from main menu
    //can be switched out as necessary

    public void quitGame()
    {
        Debug.Log("called to quit game");
        Application.Quit();
    }
}
