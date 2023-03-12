using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCardFromDeskToHand : MonoBehaviour
{
    public float yPosition;

    public bool canDestroy = false;

    private void Start()
    {
        yPosition = transform.localPosition.y;
    }

    private void Update()
    {
        transform.localPosition = Vector3.MoveTowards(
            new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z),
            new Vector3(transform.localPosition.x, yPosition, transform.localPosition.z),
            Time.deltaTime * 2400f);
        if (transform.localPosition.y == yPosition && canDestroy)
            Destroy(gameObject);
    }
}
