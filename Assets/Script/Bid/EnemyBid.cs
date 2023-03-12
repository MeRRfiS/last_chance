using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBid : MonoBehaviour
{
    public static int enemyAllChips = 1000;
    public static int enemyBidChips = 0;

    private Text allChipsText;
    private Text bidChipsText;

    private void Start()
    {
        allChipsText = GameObject.Find("All Chips Enemy").GetComponent<Text>();
        bidChipsText = GameObject.Find("Bid Chips Enemy").GetComponent<Text>();
        allChipsText.text = enemyAllChips.ToString();
        bidChipsText.text = enemyBidChips.ToString();
    }

    public void MakeBid()
    {
        if (enemyAllChips == 0) return;
        enemyBidChips = 0;
        enemyBidChips = Random.Range(50, 201);
        if (enemyBidChips >= enemyAllChips)
            enemyBidChips = enemyAllChips;
        enemyAllChips -= enemyBidChips;
    }

    private void FixedUpdate()
    {
        allChipsText.text = enemyAllChips.ToString();
        bidChipsText.text = enemyBidChips.ToString();
    }
}
