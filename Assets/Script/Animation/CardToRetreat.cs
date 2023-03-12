using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToRetreat : MonoBehaviour
{
    public Vector3 position;
    public static bool tempVer = true;

    private void Start()
    {
        if (gameObject.tag != "Shirt")
            position = new Vector3(-2500, transform.localPosition.y, 0);
        else
            position = new Vector3(0, 0, transform.localPosition.z);
    }

    private void Update()
    {
        transform.localPosition = Vector3.MoveTowards(
        transform.localPosition,
        position,
        Time.deltaTime * 4000f);
        if (transform.localPosition == position && gameObject.tag != "Shirt")
            Destroy(gameObject);
        if (transform.localPosition == position && gameObject.tag == "Shirt")   //Here sound
            if (tempVer)
            {
                PlaySoundCardDeck.PlaySound = true;
                tempVer = false;
            }
    }
}
