using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDialog : MonoBehaviour
{
    [Header("Window")]
    [SerializeField]
    public GameObject dialogWindow;

    private Text dialogText;

    public static List<string> dialog = new List<string>();

    public static int numberReplic = 0;
    public static int numberDialog = 0;

    private bool alreadyRead = false;

    private void Start()
    {
        dialogText = dialogWindow.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        LoadDialog();
    }

    public void LoadDialog()
    {
        dialog.Clear();
        for (int i = 0; i < LangSystem.lng.Henchmen.Length; i++)
            dialog.Add(LangSystem.lng.Henchmen[i]);
        dialogText.text = dialog[0];
        dialogWindow.SetActive(true);
    }

    private void Update()
    {
        SystemControl.readDialog = dialogWindow.activeSelf;
        if (!dialogWindow.activeSelf) return;
        dialogText.text = dialog[numberReplic];
        if (Input.GetMouseButtonDown(0)) numberReplic++;
        if (numberReplic == dialog.Count)
        {
            dialogWindow.SetActive(false);
            dialog.Clear();
            numberReplic = 0;
            SystemControl.blockUI = true;
            SystemControl.readDialog = false;
            Destroy(gameObject.GetComponent<EnemyDialog>());
        }
    }
}
