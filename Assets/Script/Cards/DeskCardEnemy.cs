using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskCardEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject cardCollection;
    [SerializeField]
    private EnemyBid chips;

    public static List<GameObject> enemyDeckCard = new List<GameObject>();
    public static List<Transform> deckCard = new List<Transform>();

    private int tactick = 0;
    private int countCard;

    public static float xPosition = -600;

    private void Awake()
    {
        for (int i = 0; i < 12; i++)
        {
            deckCard.Add(cardCollection.transform.GetChild(
                Random.Range(0, cardCollection.transform.childCount)));
        }
        var chance = Random.Range(1, 11);
        if (chance <= 3)
            tactick = 1;
        else if (chance <= 6)
            tactick = 2;
        else
            tactick = 3;
    }

    private Transform RegenarateCard(Transform newCard)
    {
        Destroy(newCard.gameObject);
        return Instantiate(cardCollection.transform.GetChild(
            Random.Range(0, cardCollection.transform.childCount)),
            gameObject.transform.GetChild(4));
    }

    private void EnemyTactick(ref Transform newCard)
    {
        switch (tactick)
        {
            case 1:
                while (newCard.tag != "Attack")
                {
                    var chance = Random.Range(1, 11);
                    if (chance > 5) break;
                    newCard = RegenarateCard(newCard);
                }
                break;
            case 2:
                while (newCard.tag != "Protect")
                {
                    var chance = Random.Range(1, 11);
                    if (chance > 5) break;
                    newCard = RegenarateCard(newCard);
                }
                break;
            case 3:
                break;
        }
    }

    private void ChangeCard()
    {
        for (int i = 0; i < enemyDeckCard.Count; i++)
        {
            var chanceChange = Random.Range(1, 11);
            if (chanceChange > 4) continue;
            var deleteCard = enemyDeckCard[i];
            var newCard = Instantiate(deckCard[Random.Range(0, deckCard.Count)],
                gameObject.transform.GetChild(4));
            EnemyTactick(ref newCard);
            enemyDeckCard.Add(newCard.gameObject);
            newCard.localScale = new Vector3(1f, 1f, 1);
            newCard.localPosition = new Vector3(deleteCard.transform.localPosition.x, 1200, 0);
            newCard.gameObject.AddComponent<EnemyCardAppearence>();
            newCard.gameObject.AddComponent<EnemyHand>();
            enemyDeckCard.Remove(deleteCard);
            Destroy(deleteCard);
        }
    }

    public void StartRound()
    {
        countCard = Random.Range(1, 4);
        if (enemyDeckCard.Count != 0) ChangeCard();
        for (int i = 0; i < countCard; i++)
        {
            if (enemyDeckCard.Count == 5) return;
            var newCard = Instantiate(deckCard[Random.Range(0, deckCard.Count)], 
                gameObject.transform.GetChild(4));
            EnemyTactick(ref newCard);
            enemyDeckCard.Add(newCard.gameObject);
            newCard.localScale = new Vector3(1f, 1f, 1);
            newCard.localPosition = new Vector3(xPosition, 1200, 0);
            newCard.gameObject.AddComponent<BoxCollider>();
            newCard.GetComponent<BoxCollider>().size = new Vector2(266, 400);
            newCard.GetComponent<BoxCollider>().isTrigger = true;
            newCard.gameObject.AddComponent<EnemyCardAppearence>();
            newCard.gameObject.AddComponent<EnemyHand>();
            xPosition += 300;
        }
        chips.MakeBid();
    }
}
