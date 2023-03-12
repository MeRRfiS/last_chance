using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ENDGame : MonoBehaviour
{
    public GameObject PanelEndGame;
    public Text TextENDGame;
    void Update()
    {
        if (MakeBid.allChips <= 0 && MakeBid.bidChips <= 0)
        {
            PanelEndGame.SetActive(true);
            TextENDGame.text = "Вы проиграли.";
        }

        if (EnemyBid.enemyAllChips <= 0 && EnemyBid.enemyBidChips <= 0)
        {
            PanelEndGame.SetActive(true);
            TextENDGame.text = "Вы выиграли!";
        }
    }

    public void Exit()
    {
       Application.Quit();
    }
}
