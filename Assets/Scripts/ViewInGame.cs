using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViewInGame : MonoBehaviour
{
    public TMP_Text coinsLabel;

    // Update is called once per frame
    void Update()
    {
        coinsLabel.text = GameManager.GetInstance().GetCollectedCoins().ToString();
    }
}
