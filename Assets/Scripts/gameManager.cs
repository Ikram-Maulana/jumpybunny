using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 1) Menu
 * 2) In Game
 * 3) GameOver
 * 4) Pause
 **/

enum DaysOfTheWeek: byte{
    // Monday,
    // supaya tidak dimulai dari 0 maka
    Moday = 1,
    Tuesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

public enum GameState
{
    Menu,
    InGame,
    GameOver
}

public class gameManager : MonoBehaviour
{
    // Start our game
    DaysOfTheWeek currentDay = DaysOfTheWeek.Sunday;
    public void StartGame()
    {
        print("Today is " + (int) currentDay);
    }

    private void Start()
    {
        StartGame();
    }

    // Called when player dies
    public void GameOver()
    {
        
    }

    // Called when the player decide to quit the game
    // and go to the main menu
    public void BackToMainMenu()
    {

    }
}
