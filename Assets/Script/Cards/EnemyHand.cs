using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHand : MonoBehaviour
{
    public static GameObject activeGameObject;
    private GameObject mainCamera;

    private void Start()
    {
        mainCamera = GameObject.Find("MainCamera");
    }

    private void OnMouseEnter()
    {
        if (SystemControl.blockUI) return;
        activeGameObject = gameObject;
    }

    private void OnMouseExit()
    {
        activeGameObject = null;
    }

    private void Update()
    {
        if (SystemControl.blockUI) return;
        if (Input.GetMouseButtonUp(1) && activeGameObject == gameObject)
        {
            AboutCard.readInfo = true;
            switch (activeGameObject.tag)
            {
                case "Attack":
                    if (Hand.infoCard[0]) break;
                    mainCamera.GetComponent<AboutCard>().LoadDialog(0);
                    mainCamera.GetComponent<AboutCard>().TurnOnDialog();
                    Hand.infoCard[0] = true;
                    break;
                case "Protect":
                    if (Hand.infoCard[1]) break;
                    mainCamera.GetComponent<AboutCard>().LoadDialog(1);
                    mainCamera.GetComponent<AboutCard>().TurnOnDialog();
                    Hand.infoCard[1] = true;
                    break;
                case "Angel":
                    if (Hand.infoCard[2]) break;
                    mainCamera.GetComponent<AboutCard>().LoadDialog(2);
                    mainCamera.GetComponent<AboutCard>().TurnOnDialog();
                    Hand.infoCard[2] = true;
                    break;
                case "Demon":
                    if (Hand.infoCard[3]) break;
                    if (SystemControl.educationOn)
                        mainCamera.GetComponent<AboutCard>().LoadDialog(3);
                    else mainCamera.GetComponent<AboutCard>().LoadDialog(4);
                    mainCamera.GetComponent<AboutCard>().TurnOnDialog();
                    Hand.infoCard[3] = true;
                    break;
            }
            SystemControl.blockUI = true;
            SystemControl.seeInfoCard = true;
            var informationCard = Instantiate(
                activeGameObject,
                activeGameObject.transform.parent.parent);
            informationCard.transform.localScale = new Vector3(3, 3, 1);
            informationCard.transform.localPosition = new Vector3(2500, 0, 0);
            informationCard.AddComponent<StopWatchCard>();
            informationCard.AddComponent<OpenInfoCard>();
            Destroy(informationCard.GetComponent<MoveCardOnHand>());
            Destroy(informationCard.GetComponent<Hand>());
        }
    }
}
