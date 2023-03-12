using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceProperties : MonoBehaviour
{
    public Vector3 diceVelocity;
    public bool canCountDot = false;

    private void FixedUpdate()
    {
        diceVelocity = GetComponent<Rigidbody>().velocity;
    }
}
