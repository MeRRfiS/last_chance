using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retreat : MonoBehaviour
{
    private Vector3 position;

    public static List<int> retreatIndex = new List<int>();

    private GameObject activeObject;
    private GameObject spawnCard;
    public GameObject shirtCard;

    private void Start()
    {
        spawnCard = GameObject.Find("Card Spawn");
    }

    private void OnMouseEnter()
    {
        if (SystemControl.blockUI) return;
        activeObject = gameObject;
    }

    private void OnMouseExit()
    {
        activeObject = null;
    }

    void Update()
    {
        if (retreatIndex.Count != 0) GetComponent<BoxCollider>().isTrigger = true;
        if (SystemControl.blockUI) return;
        if (Input.GetMouseButtonUp(0) && activeObject != null)
        {
            //Change to 20
            if (DiceNumberTextScript.diceNumber < 20) return;
            DiceNumberTextScript.diceNumber -= 20;
            StartCoroutine(TakeCardFromRetreat());
        }
    }

    private IEnumerator TakeCardFromRetreat()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            transform.GetChild(i).GetComponent<CardToRetreat>().position  = new Vector3(2000, 0, transform.localPosition.z);
            CardToRetreat.tempVer = true; //sound
            yield return new WaitForSeconds(0.5f);
            Destroy(transform.GetChild(i).gameObject);
            var newCard = Instantiate(shirtCard, spawnCard.transform);
            newCard.transform.localScale = new Vector3(1, 1, 1);
            newCard.transform.localPosition = new Vector3(2000, 0, StartGame.zPosition);
            StartGame.zPosition -= 2;
            StartGame.cardDeskIndex.Add(retreatIndex[0]);
            StartGame.cardDeskCount++;
            retreatIndex.Remove(retreatIndex[0]);
            newCard.AddComponent<CardToDesk>();
        }
        Destroy(gameObject.GetComponent<BoxCollider>());
        Destroy(gameObject.GetComponent<Retreat>());
    }
}
