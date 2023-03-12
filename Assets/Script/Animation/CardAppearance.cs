using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAppearance : MonoBehaviour
{
    private Vector3 position;

    public Transform desk;

    private void Start()
    {
        position = new Vector3(transform.localPosition.x, -750, transform.localPosition.z);
    }

    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(
            transform.localPosition,
            position,
            Time.deltaTime * 2000f);
        if (transform.localPosition.y == position.y)
        {
            gameObject.AddComponent<Hand>();
            gameObject.AddComponent<MoveCardOnHand>();
            gameObject.GetComponent<Hand>().deskCard = desk.GetComponent<DeskCard>();
            Destroy(GetComponent<CardAppearance>());
        }
    }
}
