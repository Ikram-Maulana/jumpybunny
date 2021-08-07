using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViewInGame : MonoBehaviour
{
    public TMP_Text coinsLabel;
    public TMP_Text scoreText;
    public TMP_Text highestScoreText;

    private static ViewInGame sharedInstance;

    private void Awake()
    {
        sharedInstance = this;
    }

    public static ViewInGame GetInstance()
    {
        return sharedInstance;
    }

    public void ShowHighestScore()
    {
        highestScoreText.text = playerController.GetInstance().GetMaxScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //if(GameManager.GetInstance().currentGameState == GameState.Menu)
        //{
        //    showHighestScore();
        //}
        if (GameManager.GetInstance().currentGameState == GameState.InGame)
        {
            //coinsLabel.text = GameManager.GetInstance().GetCollectedCoins().ToString();
            scoreText.text = playerController.GetInstance().GetDistance().ToString();
        }
    }

    public void UpdateCoins()
    {
        coinsLabel.text = GameManager.GetInstance().GetCollectedCoins().ToString();
    }
}
