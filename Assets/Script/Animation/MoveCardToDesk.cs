using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCardToDesk : MonoBehaviour
{
    private Vector3 position;

    private float xPosition;

    private GameObject desk;

    private void Start()
    {
        xPosition = DeskCard.xPosition;
        desk = GameObject.Find("Table Canvas");
    }

    private void Update()
    {
        position = new Vector3(xPosition, -230, 0);
        gameObject.transform.localPosition = Vector3.MoveTowards(
            gameObject.transform.localPosition,
            position,
            Time.deltaTime * 4000f);
        if (gameObject.transform.localPosition == position)
        {
            desk.GetComponent<DeskCard>().AddCard(gameObject);
            Destroy(gameObject);
        }
    }
}
