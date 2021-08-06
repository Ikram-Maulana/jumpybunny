using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// for canvas
using UnityEngine.UI;

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
    GameOver,
    Resume
}

public class GameManager : MonoBehaviour
{
    // Start our game
    // DaysOfTheWeek currentDay = DaysOfTheWeek.Sunday;
    public GameState currentGameState = GameState.Menu;
    private static GameManager sharedInstance;
    public Canvas mainMenu;
    public Canvas GameMenu;
    public Canvas GameOverMenu;

    private void Awake()
    {
        sharedInstance = this;
    }

    public static GameManager GetInstance()
    {
        return sharedInstance;
    }

    public void StartGame()
    {
        LevelGenerator.sharedInstance.CreateInitialBlocks();
        // print("Today is " + (int) currentDay);
        playerController.GetInstance().StartGame();
        ChangeGameState(GameState.InGame);
    }

    private void Start()
    {
        // StartGame();
        currentGameState = GameState.Menu;
        mainMenu.enabled = true;
        GameMenu.enabled = false;
        GameOverMenu.enabled = false;
    }

    private void Update()
    {
        if (currentGameState != GameState.InGame && Input.GetKeyDown("s"))
        {
            ChangeGameState(GameState.InGame);
            StartGame();
        }
    }

    // Called when player dies
    public void GameOver()
    {
        LevelGenerator.sharedInstance.RemoveAllBlocks();
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
                mainMenu.enabled = true;
                GameMenu.enabled = false;
                GameOverMenu.enabled = false;
                break;
            case GameState.InGame:
                // Unity Scene must show the Real Game
                mainMenu.enabled = false;
                GameMenu.enabled = true;
                GameOverMenu.enabled = false;
                break;
            case GameState.GameOver:
                // Lets load end of the game scene
                mainMenu.enabled = false;
                GameMenu.enabled = false;
                GameOverMenu.enabled = true;
                break;
            default:
                currentGameState = GameState.Menu;
                break;
        }
        currentGameState = newGameState;
    }
}
