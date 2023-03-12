using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatchCard : MonoBehaviour
{
    private bool canDestroy = false;

    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            if (EduDialog.numberDialog == 5)
            {
                GameObject.Find("MainCamera").GetComponent<EduDialog>().TurnOffHint();
            }
            SystemControl.blockUI = false;
            SystemControl.seeInfoCard = false;
            gameObject.GetComponent<OpenInfoCard>().position = new Vector3(2500, 0, 0);
            canDestroy = true;
        }
        if(transform.localPosition == gameObject.GetComponent<OpenInfoCard>().position && canDestroy)
            Destroy(gameObject);
    }
}
