using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject retreat;
    public GameObject spawnCard;

    public void AllClear()
    {
        for (int i = 0; i < Hand.myHand.Count; i++)
        {
            Destroy(Hand.myHand[i]);
        }
        Hand.myHand.Clear();
        Hand.myHandIndex.Clear();
        for (int i = 0; i < DeskCard.myDeckCard.Count; i++)
        {
            Destroy(DeskCard.myDeckCard[i]);
        }
        DeskCard.myDeckCard.Clear();
        DeskCard.myDeckCardIndex.Clear();
        for (int i = 0; i < DeskCardEnemy.enemyDeckCard.Count; i++)
        {
            Destroy(DeskCardEnemy.enemyDeckCard[i]);
        }
        DeskCardEnemy.enemyDeckCard.Clear();
        List<GameObject> a = new List<GameObject>();
        for (int i = 0; i < retreat.transform.childCount; i++)
        {
            a.Add(retreat.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < a.Count; i++)
        {
            Destroy(a[i]);
        }
        a.Clear();
        for (int i = 0; i < spawnCard.transform.childCount; i++)
        {
            a.Add(spawnCard.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < a.Count; i++)
        {
            Destroy(a[i]);
        }
        StartGame.cardDeskIndex.Clear();
        ButtleScript.xPosition = -800;
        ButtleScript.cardIndex = 0;
        DeskCard.xPosition = -600;
        DeskCardEnemy.xPosition = -600;
        MakeBid.allChips = 1000;
        MakeBid.bidChips = 0;
        EnemyBid.enemyAllChips = 1000;
        EnemyBid.enemyBidChips = 0;
    }
}
