using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskCard : MonoBehaviour
{
    public static List<GameObject> myDeckCard = new List<GameObject>();
    public static List<int> myDeckCardIndex = new List<int>();

    public static float xPosition = -600;

    public void AddCard(GameObject addNewCard)
    {
        if (myDeckCard.Count == 5) return;
        var newCard = Instantiate(addNewCard, gameObject.transform.GetChild(3));
        Destroy(newCard.GetComponent<MoveCardToDesk>());
        myDeckCard.Add(newCard.gameObject);
        newCard.AddComponent<DestroyCard>();
        newCard.transform.localScale = new Vector3(1f, 1f, 1);
        newCard.transform.localPosition = new Vector3(xPosition, -230, 0);
        xPosition += 300;
        newCard.AddComponent<MoveCardOnTable>();
    }
}
