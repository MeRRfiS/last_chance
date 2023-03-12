using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeBid : MonoBehaviour
{
    public GameObject bid;
    public Text bidChipsText;
    public Text allChipsText;
    public static int allChips = 1000;
    public static int bidChips = 0;

    void Start()
    {
        allChipsText.text = (allChips-bidChips).ToString();
        bid.SetActive(false);
    }
    public void BidActive()
    {
        SystemControl.blockUI = true;
        if(EduDialog.numberDialog == 2)
        {
            EduDialog.numberReplic = 0;
            GameObject.Find("MainCamera").GetComponent<EduDialog>().TurnOnDialog();
        }
        bidChips = 50;
        bidChipsText.text = bidChips.ToString();
        bid.SetActive(true);
    }
    public void ConfirmBid()
    {
        SystemControl.blockUI = false;
        if (EduDialog.numberDialog == 3)
        {
            EduDialog.numberReplic = 0;
            GameObject.Find("MainCamera").GetComponent<EduDialog>().TurnOnDialog();
        }
        bid.SetActive(false);
        if (bidChips >= 100 && bidChips < 150)
            DiceNumberTextScript.diceNumber += 1;
        else if (bidChips >= 150 && bidChips < 200)
            DiceNumberTextScript.diceNumber += 2;
        else if (bidChips == 200)
            DiceNumberTextScript.diceNumber += 4;
        allChips -= bidChips;
        SystemControl.madeBid = true;
    }
    //    -10   -1
    public void minusTen()
    {
        if(bidChips - 10 >= 50 && (allChips - bidChips) >= 0)
        {
            bidChips -= 10;
            bidChipsText.text = bidChips.ToString();
            allChipsText.text = (allChips - bidChips).ToString();
        }
    }
    public void minusOne()
    {
        if (bidChips - 1 >= 50 && (allChips - bidChips) >= 0)
        {
            bidChips -= 1;
            bidChipsText.text = bidChips.ToString();
            allChipsText.text = (allChips - bidChips).ToString();
        }
    }

    //    +10   +1
    public void plusTen()
    {
        if (bidChips + 10 <= 200 && (allChips - bidChips) >= 0)
        {
            bidChips += 10;
            bidChipsText.text = bidChips.ToString();
            allChipsText.text = (allChips - bidChips).ToString();
        }
    }
    public void plusOne()
    {
        if (bidChips + 1 <= 200 && (allChips - bidChips) >= 0)
        {
            bidChips += 1;
            bidChipsText.text = bidChips.ToString();
            allChipsText.text = (allChips - bidChips).ToString();
        }
    }
}