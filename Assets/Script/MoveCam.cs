using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCam : MonoBehaviour
{
    private Camera Camera;

    private Vector3 direction;
    private Vector3 position;
    private Quaternion rotate;

    public static bool boolCamMain = true;

    [SerializeField]
    private Button endRound;
    [SerializeField]
    private Button bid;

    private void Start()
    {
        rotate = gameObject.transform.rotation;
        position = gameObject.transform.position;
        Camera = GetComponent<Camera>();
    }
    void Update()
    {
        Camera.transform.position = Vector3.MoveTowards(Camera.transform.position, position, Time.deltaTime * 18f);
        Camera.transform.rotation = Quaternion.Lerp(Camera.transform.rotation, rotate, Time.deltaTime * 6f);

        if (SystemControl.readDialog) return;

        if (Input.GetKeyDown(KeyCode.W) && !SystemControl.seeInfoCard) 
        {
            if(EduDialog.numberDialog == 1 && SystemControl.educationOn)
            {
                EduDialog.numberReplic = 0;
                gameObject.GetComponent<EduDialog>().TurnOnDialog();
                gameObject.GetComponent<StartGame>().RunGame();
            }
            if(EduDialog.numberDialog == 10 && SystemControl.educationOn)
            {
                EduDialog.numberReplic = 0;
                gameObject.GetComponent<EduDialog>().TurnOnDialog();
            }

            if(SystemControl.startGame && !SystemControl.educationOn)
            {
                SystemControl.startGame = false;
                gameObject.GetComponent<StartGame>().RunGame();
            }
            
            boolCamMain = !boolCamMain;
            SystemControl.blockUI = !SystemControl.blockUI;
        }

        if (SystemControl.blockUI || !SystemControl.madeBid)
            endRound.interactable = false;
        else
            endRound.interactable = true;
        if (SystemControl.blockUI || SystemControl.madeBid)
            bid.interactable = false;
        else
            bid.interactable = true;

        if (!boolCamMain)
        {
            //position = new Vector3(0, 12.3f, 0.025f);
            //direction = new Vector3(90f, 0, 0);
            position = new Vector3(0, 12.31f, -4.42f);
            direction = new Vector3(66.4f, 0, 0);
            rotate = Quaternion.Euler(direction);
        }
        else
        {
            position = new Vector3(0, 9f, -12.5f);
            direction = new Vector3(7f, 0, 0);
            rotate = Quaternion.Euler(direction);
        }
    }
}