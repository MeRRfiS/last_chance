using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToDesk : MonoBehaviour
{
    public Vector3 position;

    private void Start()
    {
        position = new Vector3(0, 0, transform.localPosition.z);
    }

    private void Update()
    {
        transform.localPosition = Vector3.MoveTowards(
        transform.localPosition,
        position,
        Time.deltaTime * 6500f);
        if (transform.localPosition == position)
        {
            PlaySoundCardDeck.PlaySound = true;
            gameObject.AddComponent<TakeCardFromDeskToHand>();
            Destroy(gameObject.GetComponent<CardToDesk>());
        }
    }
}
