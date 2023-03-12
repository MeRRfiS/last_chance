using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public static List<GameObject> myHand = new List<GameObject>();
    public static List<int> myHandIndex = new List<int>();
    public static GameObject activeGameObject;

    public Vector3 position;

    public DeskCard deskCard;

    private GameObject mainCamera;

    public static bool[] infoCard = { false, false, false, false };
    private static bool showedHind = false;

    private void Start()
    {
        position = transform.localPosition;
        mainCamera = GameObject.Find("MainCamera");
    }

    private void OnMouseEnter()
    {
        if (SystemControl.blockUI || SystemControl.readDialog) return;
        position = new Vector3(transform.localPosition.x, -575f, transform.localPosition.z);
        activeGameObject = gameObject;
        PlaySoundOnMouseCard.PlaySound = true;
    }

    private void OnMouseExit()
    {
        position = new Vector3(transform.localPosition.x, -750f, transform.localPosition.z);
        activeGameObject = null;
    }

    private void Update()
    {
        transform.localPosition = Vector3.MoveTowards(
            new Vector3(transform.localPosition.x, transform.localPosition.y, 0),
            new Vector3(transform.localPosition.x, position.y, 0),
            Time.deltaTime * 800f);
        if (SystemControl.blockUI || SystemControl.readDialog) return;
        if (Input.GetMouseButtonUp(0) && activeGameObject == gameObject && DeskCard.myDeckCard.Count != 5)
        {
            if (DiceNumberTextScript.diceNumber < activeGameObject.GetComponent<CardProperties>().properties["Price"]) return;
            DiceNumberTextScript.diceNumber -= activeGameObject.GetComponent<CardProperties>().properties["Price"];
            if (EduDialog.numberDialog == 5)
            {
                EduDialog.numberReplic = 0;
                GameObject.Find("MainCamera").GetComponent<EduDialog>().TurnOnDialog();
            }
            var moveCard = Instantiate(
                activeGameObject, 
                activeGameObject.transform.position, 
                activeGameObject.transform.rotation, 
                activeGameObject.transform.parent);
            Destroy(moveCard.GetComponent<MoveCardOnHand>());
            Destroy(moveCard.GetComponent<Hand>());
            //Here sound
            PlaySoundHand.PlaySound = true;
            moveCard.AddComponent<MoveCardToDesk>();
            DeskCard.myDeckCardIndex.Add(myHandIndex[myHand.IndexOf(activeGameObject)]);
            ButtleScript.xPosition -= 300;
            for (int i = myHand.IndexOf(activeGameObject) + 1; i < myHand.Count; i++)
            {
                myHand[i].GetComponent<MoveCardOnHand>().position = new Vector3(
                    myHand[i].transform.localPosition.x - 300,
                    myHand[i].transform.localPosition.y,
                    myHand[i].transform.localPosition.z);
            }
            myHandIndex.Remove(myHandIndex[myHand.IndexOf(activeGameObject)]);
            myHand.Remove(activeGameObject);
            Destroy(activeGameObject);
        }
        if(Input.GetMouseButtonUp(1) && activeGameObject == gameObject)
        {
            if(EduDialog.numberDialog == 5 && !showedHind)
            {
                print(showedHind);
                mainCamera.GetComponent<EduDialog>().TurnOffHint();
                mainCamera.GetComponent<EduDialog>().TurnOnHint(4);
                showedHind = true;
                print(showedHind);
            }
            AboutCard.readInfo = true;
            if(SystemControl.educationOn)
                mainCamera.GetComponent<EduDialog>().enabled = false;
            switch (activeGameObject.tag)
            {
                case "Attack":
                    if (infoCard[0]) break;
                    mainCamera.GetComponent<AboutCard>().LoadDialog(0);
                    mainCamera.GetComponent<AboutCard>().TurnOnDialog();
                    infoCard[0] = true;
                    break;
                case "Protect":
                    if (infoCard[1]) break;
                    mainCamera.GetComponent<AboutCard>().LoadDialog(1);
                    mainCamera.GetComponent<AboutCard>().TurnOnDialog();
                    infoCard[1] = true;
                    break;
                case "Angel":
                    if (infoCard[2]) break;
                    mainCamera.GetComponent<AboutCard>().LoadDialog(2);
                    mainCamera.GetComponent<AboutCard>().TurnOnDialog();
                    infoCard[2] = true;
                    break;
                case "Demon":
                    if (infoCard[3]) break;
                    if (SystemControl.educationOn)
                        mainCamera.GetComponent<AboutCard>().LoadDialog(3);
                    else mainCamera.GetComponent<AboutCard>().LoadDialog(4);
                    mainCamera.GetComponent<AboutCard>().TurnOnDialog();
                    infoCard[3] = true;
                    break;
            }
            SystemControl.blockUI = true;
            SystemControl.seeInfoCard = true;
            var informationCard = Instantiate(
                activeGameObject,
                activeGameObject.transform.parent);
            informationCard.transform.localScale = new Vector3(3, 3, 1);
            informationCard.transform.localPosition = new Vector3(2500, 0, 0);
            informationCard.AddComponent<StopWatchCard>();
            informationCard.AddComponent<OpenInfoCard>();
            Destroy(informationCard.GetComponent<MoveCardOnHand>());
            Destroy(informationCard.GetComponent<Hand>());
        }
    }
}
