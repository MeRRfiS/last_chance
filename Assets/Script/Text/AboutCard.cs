using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutCard : MonoBehaviour
{
    [Header("Window")]
    [SerializeField]
    private GameObject dialogWindow;
    [SerializeField]
    private GameObject hintWindow;

    private Text dialogText;
    private Text hintText;

    private List<string> dialog = new List<string>();
    public static int numberDialog = 0;
    public static int numberReplic = 0;

    public static bool readInfo = false;

    void Start()
    {
        dialogText = dialogWindow.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        hintText = hintWindow.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        LoadDialog(0);
    }

    public void LoadDialog(int index)
    {
        dialog.Clear();
        for (int i = 0; i < LangSystem.lng.aboutCard[index].Length; i++)
            dialog.Add(LangSystem.lng.aboutCard[index][i]);
        dialogText.text = dialog[0];
    }

    public void TurnOnDialog()
    {
        dialogWindow.SetActive(true);
    }

    void Update()
    {
        if (!readInfo) return;
        SystemControl.blockUI = false;
        SystemControl.readDialog = dialogWindow.activeSelf;
        if (!dialogWindow.activeSelf) return;
        dialogText.text = dialog[numberReplic];
        if (Input.GetMouseButtonDown(0)) numberReplic++;
        if (numberReplic == dialog.Count)
        {
            SystemControl.readDialog = false;
            dialogWindow.SetActive(false);
            numberReplic = 0;
            readInfo = false;
            if(SystemControl.educationOn)
                gameObject.GetComponent<EduDialog>().enabled = true;
            SystemControl.blockUI = true;
        }
    }
}
