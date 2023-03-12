using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BidStatistic : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (gameObject.name == "All Chips")
            gameObject.GetComponent<Text>().text = MakeBid.allChips.ToString();
        else
            gameObject.GetComponent<Text>().text = MakeBid.bidChips.ToString();
    }
}
