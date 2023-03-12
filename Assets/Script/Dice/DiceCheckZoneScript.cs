using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour
{
    private Vector3 diceVelocity;


    private void FixedUpdate()
    {
        diceVelocity = transform.parent.GetComponent<DiceProperties>().diceVelocity;
    }

    private void CountDiceNumber(int countDot)
    {
        DiceNumberTextScript.diceNumber += countDot;
        transform.parent.GetComponent<DiceProperties>().canCountDot = false;
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.name != "DiceCheckZone") return;
        if (!transform.parent.GetComponent<DiceProperties>().canCountDot) return;
        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
        {
            switch (gameObject.name)
            {
                case "Sider1":
                    CountDiceNumber(6);
                    break;
                case "Sider2":
                    CountDiceNumber(5);
                    break;
                case "Sider3":
                    CountDiceNumber(4);
                    break;
                case "Sider4":
                    CountDiceNumber(3);
                    break;
                case "Sider5":
                    CountDiceNumber(2);
                    break;
                case "Sider6":
                    CountDiceNumber(1);
                    break;
            }
        }
    }
}
