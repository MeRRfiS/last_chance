using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtleScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cardCollection;
    [SerializeField]
    private GameObject cardDesk;
    [SerializeField]
    private GameObject shirtCard;
    private GameObject retreat;
    [SerializeField]
    private Transform desk;

    [Header("Buttlefields")]
    [SerializeField]
    private GameObject buttlefield;
    [SerializeField]
    private GameObject buttlefieldEnemy;

    private Animation buttlefieldAnimation;
    private Animation buttlefieldEnemyAnimation;

    [Header("Text")]
    [SerializeField]
    private Text myDamageText;
    [SerializeField]
    private Text enemyDamageText;

    private AudioSource AudioS;

    public static float xPosition = -800;
    private float zRetreatPosition = 0;

    public static int cardIndex = 0;

    private void Start()
    {
        buttlefieldAnimation = buttlefield.GetComponent<Animation>();
        buttlefieldEnemyAnimation = buttlefieldEnemy.GetComponent<Animation>();
        retreat = GameObject.Find("Retreat");
        AudioS = this.gameObject.GetComponent<AudioSource>();
    }

    public void EndRound()
    {
        buttlefieldAnimation.Play();
        buttlefieldEnemyAnimation.Play();
        DiceNumberTextScript.diceNumber = 0;
        StartCoroutine(ResultButtle());
        StartCoroutine(TakeCard(1));

        PlaySoundOnMouseEndRound.PlaySound = true;
    }

    private void RetreatCard(GameObject _buttlefield, bool wasDemon = false, int howMush = 0)
    {
        List<GameObject> retreat = new List<GameObject>();
        for (int i = 0; i < _buttlefield.transform.childCount; i++)
        {
            switch (_buttlefield.name)
            {
                case "Buttlefield":
                    DeskCard.myDeckCard.Remove(DeskCard.myDeckCard[0]);
                    DeskCard.xPosition -= 300;
                    retreat.Add(_buttlefield.transform.GetChild(i).gameObject);
                    Retreat.retreatIndex.Add(DeskCard.myDeckCardIndex[i]);
                    EnemyBid.enemyAllChips += MakeBid.bidChips + EnemyBid.enemyBidChips;
                    MakeBid.bidChips = 0;
                    EnemyBid.enemyBidChips = 0;
                    break;
                case "Buttlefield Enemy":
                    var card = DeskCardEnemy.enemyDeckCard[0];
                    DeskCardEnemy.enemyDeckCard.Remove(card);
                    Destroy(card);
                    DeskCardEnemy.xPosition -= 300;
                    MakeBid.allChips += MakeBid.bidChips + EnemyBid.enemyBidChips;
                    EnemyBid.enemyBidChips = 0;
                    MakeBid.bidChips = 0;
                    if (EduDialog.numberDialog == 6)
                    {
                        EduDialog.numberReplic = 0;
                        GameObject.Find("MainCamera").GetComponent<EduDialog>().TurnOnDialog();
                    }
                    break;
            }
        }
        switch (_buttlefield.name)
        {
            case "Buttlefield":
                EnemyBid.enemyAllChips += MakeBid.bidChips + EnemyBid.enemyBidChips;
                MakeBid.bidChips = 0;
                EnemyBid.enemyBidChips = 0;
                break;
            case "Buttlefield Enemy":
                MakeBid.allChips += MakeBid.bidChips + EnemyBid.enemyBidChips;
                EnemyBid.enemyBidChips = 0;
                MakeBid.bidChips = 0;
                break;
        }
        if (wasDemon)
        switch (_buttlefield.name)
        {
            case "Buttlefield":
                    for (int i = 0; i < howMush; i++)
                    {
                        MakeBid.allChips -= UnityEngine.Random.Range(50, 101);
                    }
                break;
            case "Buttlefield Enemy":
                    for (int i = 0; i < howMush; i++)
                    {
                        EnemyBid.enemyAllChips -= UnityEngine.Random.Range(50, 101);
                    }
                    break;
        }
        if (retreat.Count != 0)
            StartCoroutine(CardToRetreat(retreat));
    }

    private IEnumerator CardToRetreat(List<GameObject> cards)
    {
        foreach (var card in cards)
        {
            card.AddComponent<CardToRetreat>();
            yield return new WaitForSeconds(0.5f);
            var newCardInRetrest = Instantiate(shirtCard, retreat.transform);
            newCardInRetrest.transform.localScale = new Vector3(1, 1, 1);
            newCardInRetrest.transform.localPosition = new Vector3(2000, 0, zRetreatPosition);
            zRetreatPosition -= 2;
            newCardInRetrest.AddComponent<CardToRetreat>();
        }
        if (EduDialog.numberDialog == 6)
        {
            EduDialog.numberDialog++;
            EduDialog.numberReplic = 0;
            GameObject.Find("MainCamera").GetComponent<EduDialog>().LoadDialog();
            GameObject.Find("MainCamera").GetComponent<EduDialog>().TurnOnDialog();
        }
    }

    private IEnumerator ResultButtle()
    {
        yield return new WaitForSeconds(1f);
        var wasDemon = false;
        var wasDemonEnemy = false;
        var howMushDemon = 0;
        var howMushDemonEnemy = 0;
        var damage = 0;
        var protectCound = 0;
        var enemyDamage = 0;
        var protectCountEnemy = 0;
        for (int i = 0; i < buttlefield.transform.childCount; i++)
            if (0 == buttlefield.transform.GetChild(i).GetComponent<CardProperties>().properties["idEffect"])
            {
                damage += buttlefield.transform.GetChild(i).GetComponent<CardProperties>().properties["Damage"];
                protectCound += buttlefield.transform.GetChild(i).GetComponent<CardProperties>().properties["Protect"];
            }

        for (int i = 0; i < buttlefieldEnemy.transform.childCount; i++)
            if (0 == buttlefieldEnemy.transform.GetChild(i).GetComponent<CardProperties>().properties["idEffect"])
            {
                enemyDamage += buttlefieldEnemy.transform.GetChild(i).GetComponent<CardProperties>().properties["Damage"];
                protectCountEnemy += buttlefieldEnemy.transform.GetChild(i).GetComponent<CardProperties>().properties["Protect"];
            }
        for (int i = 0; i < buttlefield.transform.childCount; i++)
            if (0 != buttlefield.transform.GetChild(i).GetComponent<CardProperties>().properties["idEffect"])
            {
                int idEffect = buttlefield.transform.GetChild(i).GetComponent<CardProperties>().properties["idEffect"];
                switch (idEffect)
                {
                    case 1:
                        damage = (int)Math.Round(damage * 1.2);
                        break;
                    case 2:
                        howMushDemon++;
                        if (damage >= protectCound)
                            protectCound = damage;
                        else
                            damage = protectCound;
                        wasDemon = true;
                        MakeBid.allChips -= UnityEngine.Random.Range(50, 101);
                        break;
                    case 3:
                        howMushDemon++;
                        damage *= 2;
                        wasDemon = true;
                        MakeBid.allChips -= UnityEngine.Random.Range(50, 101);
                        break;
                    case 4:
                        protectCound = (int)Math.Round(protectCound * 1.5);
                        break;
                    default:
                        print("ERROR!!!!");
                        break;
                }
            }
        for (int i = 0; i < buttlefieldEnemy.transform.childCount; i++)
            if (0 != buttlefieldEnemy.transform.GetChild(i).GetComponent<CardProperties>().properties["idEffect"])
            {
                int enemyidEffect = buttlefieldEnemy.transform.GetChild(i).GetComponent<CardProperties>().properties["idEffect"];
                switch (enemyidEffect)
                {
                    case 1:
                        enemyDamage = (int)Math.Round(enemyDamage * 1.2);
                        break;
                    case 2:
                        howMushDemonEnemy++;
                        if (enemyDamage >= protectCountEnemy)
                            protectCountEnemy = enemyDamage;
                        else
                            enemyDamage = protectCountEnemy;
                        wasDemonEnemy = true;
                        MakeBid.allChips -= UnityEngine.Random.Range(50, 101);
                        break;
                    case 3:
                        howMushDemonEnemy++;
                        enemyDamage *= 2;
                        wasDemonEnemy = true;
                        MakeBid.allChips -= UnityEngine.Random.Range(50, 101);
                        break;
                    case 4:
                        protectCountEnemy = (int)Math.Round(protectCountEnemy * 1.5);
                        break;
                    default:
                        print("ERROR!!!!");
                        break;
                }
            }
        var _damage = (int)Math.Round(enemyDamage - (enemyDamage * (0.05 * protectCound)));
        var _enemyDamage = (int)Math.Round(damage - (damage * (0.05 * protectCountEnemy)));
        myDamageText.text = _damage.ToString();
        enemyDamageText.text = _enemyDamage.ToString();
        if (_damage > _enemyDamage)
            RetreatCard(buttlefield, wasDemon, howMushDemon);
        else if (_damage < _enemyDamage)
            RetreatCard(buttlefieldEnemy, wasDemonEnemy, howMushDemonEnemy);
        else
        {
            EnemyBid.enemyAllChips += EnemyBid.enemyBidChips;
            MakeBid.allChips += MakeBid.bidChips;
            EnemyBid.enemyBidChips = 0;
            MakeBid.bidChips = 0;
            if (EduDialog.numberDialog == 6)
            {
                EduDialog.numberDialog+=2;
                EduDialog.numberReplic = 0;
                GameObject.Find("MainCamera").GetComponent<EduDialog>().LoadDialog();
                GameObject.Find("MainCamera").GetComponent<EduDialog>().TurnOnDialog();
            }
        }
        SystemControl.madeBid = false;
        DiceScript.canThrow = true;
    }

    public IEnumerator TakeCard(float second, int howMuch = 1)
    {
        var step = 0;
        if (xPosition != 1000)
        {
            if (cardIndex != StartGame.cardDeskIndex.Count)
            {
                while (step != howMuch)
                {
                    yield return new WaitForSeconds(second);
                    //Here sound
                    AudioS.Play();

                    cardDesk.transform.GetChild(StartGame.cardDeskCount - 1).GetComponent<TakeCardFromDeskToHand>().yPosition = -1200;
                    yield return new WaitForSeconds(0.5f);
                    cardDesk.transform.GetChild(StartGame.cardDeskCount - 1).GetComponent<TakeCardFromDeskToHand>().canDestroy = true;
                    StartGame.zPosition += 2;
                    StartGame.cardDeskCount--;
                    //myDamageText.text = "";
                    //enemyDamageText.text = "";
                    var newHandCard = Instantiate(cardCollection.transform.GetChild(StartGame.cardDeskIndex[cardIndex]), desk);
                    newHandCard.localScale = new Vector3(1f, 1f, 1);
                    newHandCard.localPosition = new Vector3(xPosition, -1200f, 1f);
                    newHandCard.gameObject.AddComponent<CardAppearance>().desk = desk;
                    newHandCard.gameObject.AddComponent<BoxCollider>();
                    newHandCard.GetComponent<BoxCollider>().size = new Vector2(266, 400);
                    newHandCard.GetComponent<BoxCollider>().isTrigger = true;
                    Hand.myHand.Add(newHandCard.gameObject);
                    Hand.myHandIndex.Add(StartGame.cardDeskIndex[cardIndex]);
                    cardIndex++;
                    if (cardIndex == StartGame.cardDeskIndex.Count)
                    {
                        retreat.AddComponent<BoxCollider>();
                        retreat.GetComponent<BoxCollider>().size = new Vector2(266, 400);
                        retreat.GetComponent<BoxCollider>().isTrigger = false;
                        retreat.AddComponent<Retreat>();
                        retreat.GetComponent<Retreat>().shirtCard = shirtCard;
                    }
                    xPosition += 300;
                    step++;
                }
            }
            else yield return new WaitForSeconds(second + 0.5f);
        }
        else yield return new WaitForSeconds(second + 0.5f);
        desk.gameObject.GetComponent<DeskCardEnemy>().StartRound();
        yield return null;
    }
}
