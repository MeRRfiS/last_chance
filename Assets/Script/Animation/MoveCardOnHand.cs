using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCardOnHand : MonoBehaviour
{
    public Vector3 position;

    public float xPosition;

    private void Start()
    {
        position = transform.localPosition;
        xPosition = transform.localPosition.x;
    }

    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(
            new Vector3(transform.localPosition.x, transform.localPosition.y, 0),
            new Vector3(position.x, transform.localPosition.y, 0), 
            Time.deltaTime * 1200f);
    }
}
