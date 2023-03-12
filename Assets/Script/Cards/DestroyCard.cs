using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCard : MonoBehaviour
{
    private static GameObject activeGameObject;

    private void OnMouseEnter()
    {
        if (SystemControl.blockUI) return;
        activeGameObject = gameObject;
    }

    private void OnMouseExit()
    {
        activeGameObject = null;
    }

    private void Update()
    {
        try
        {
            if (Input.GetMouseButtonUp(0) && activeGameObject != null)
            {
                if (DiceNumberTextScript.diceNumber < 5) return;
                DiceNumberTextScript.diceNumber -= 5;
                DeskCard.xPosition -= 300;
                for (int i = DeskCard.myDeckCard.IndexOf(activeGameObject) + 1; i < DeskCard.myDeckCard.Count; i++)
                {
                    DeskCard.myDeckCard[i].GetComponent<MoveCardOnTable>().position = new Vector3(
                        DeskCard.myDeckCard[i].transform.localPosition.x - 300,
                        DeskCard.myDeckCard[i].transform.localPosition.y,
                        DeskCard.myDeckCard[i].transform.localPosition.z);
                }
                DeskCard.myDeckCardIndex.Remove(DeskCard.myDeckCardIndex[DeskCard.myDeckCard.IndexOf(activeGameObject)]);
                DeskCard.myDeckCard.Remove(activeGameObject);
                Destroy(activeGameObject);
                activeGameObject = null;
            }
        }
        catch (System.Exception)
        {

        }
    }
}
