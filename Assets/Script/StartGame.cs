using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private GameObject cardCollection;
    [SerializeField]
    private GameObject spawnCard;
    [SerializeField]
    private GameObject shirt;

    private DeskCardEnemy enemyHand;

    [SerializeField]
    private ButtleScript cardHand;

    public static float zPosition = 0;

    public static List<int> cardDeskIndex = new List<int>();
    private static List<GameObject> cardDesk = new List<GameObject>();
    public static int cardDeskCount;
    public static int allCard = 8;

    //Изменить на ф-ию, которая будет запускаться после разговора
    public void RunGame()
    {
        enemyHand = GameObject.Find("Table Canvas").GetComponent<DeskCardEnemy>();
        cardDesk.Clear();
        while (cardDesk.Count != allCard)
        {
            var repeat = false;
            var cardIndex = Random.Range(0, cardCollection.transform.childCount);
            foreach (var card in cardDeskIndex)
                if (cardIndex == card)
                {
                    repeat = true;
                    break;
                }
            if (repeat) continue;
            var newCardInDesk = Instantiate(shirt, spawnCard.transform);
            newCardInDesk.transform.localScale = new Vector3(1, 1, 1);
            newCardInDesk.transform.localPosition = new Vector3(
                2000,
                spawnCard.transform.position.y,
                zPosition);
            cardDesk.Add(newCardInDesk);
            zPosition -= 2;
            cardDeskIndex.Add(cardIndex);
            cardDeskCount = cardDeskIndex.Count;
        }
        StartCoroutine(MoveCardToDesk(cardDesk));
    }

    private IEnumerator MoveCardToDesk(List<GameObject> newCards)
    {
        foreach (var newCard in newCards)
        {
            newCard.AddComponent<CardToDesk>();
            yield return new WaitForSeconds(0.3f);
        }
        StartCoroutine(cardHand.TakeCard(0, 4));
    }
}
