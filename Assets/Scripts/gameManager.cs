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
    // DaysOfTheWeek currentDay = DaysOfTheWeek.Sunday;
    GameState currentGameState = GameState.Menu;

    public void StartGame()
    {
        // print("Today is " + (int) currentDay);
        ChangeGameState(GameState.InGame);
    }

    private void Start()
    {
        StartGame();
    }

    // Called when player dies
    public void GameOver()
    {
        ChangeGameState(GameState.GameOver);
    }

    // Called when the player decide to quit the game
    // and go to the main menu
    public void BackToMainMenu()
    {
        ChangeGameState(GameState.Menu);
    }

    void ChangeGameState(GameState newGameState)
    {
        /*if(newGameState == GameState.Menu)
        {
            // Lets Load mainmenustate
        } else if(newGameState == GameState.InGame)
        {
            //Unity Scene must show the Real Game
        } else if(newGameState == GameState.GameOver)
        {
            // Lets load end of the game scene
        } else {
            currentGameState = GameState.Menu;
        }
        */

        switch (newGameState)
        {
            case GameState.Menu:
                // Lets Load main menu scene
                break;
            case GameState.InGame:
                // Unity Scene must show the Real Game
                break;
            case GameState.GameOver:
                // Lets load end of the game scene
                break;
            default:
                currentGameState = GameState.Menu;
                break;
        }
        currentGameState = newGameState;
    }
}
