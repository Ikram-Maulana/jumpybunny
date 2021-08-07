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

    private void Start()
    {
        
    }

    void showHighestScore()
    {
        highestScoreText.text = playerController.GetInstance().GetMaxScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.GetInstance().currentGameState == GameState.Menu)
        {
            showHighestScore();
        }
        coinsLabel.text = GameManager.GetInstance().GetCollectedCoins().ToString();
        scoreText.text = playerController.GetInstance().GetDistance().ToString();
    }
}
