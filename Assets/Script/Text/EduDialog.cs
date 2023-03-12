using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EduDialog : MonoBehaviour
{
    [Header("Window")]
    [SerializeField]
    private GameObject dialogWindow;
    [SerializeField]
    private GameObject hintWindow;

    private Text dialogText;
    private Text hintText;

    public static List<string> dialog = new List<string>();

    public static int numberReplic = 0;
    public static int numberDialog = 0;

    private void Start()
    {
        dialogText = dialogWindow.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        hintText = hintWindow.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        LoadDialog();
    }

    public void LoadDialog()
    {
        var index = numberDialog;
        if (numberDialog == 10)
            index--;
        dialog.Clear();
        for (int i = 0; i < LangSystem.lng.eduDialog[index].Length; i++)
            dialog.Add(LangSystem.lng.eduDialog[index][i]);
        dialogText.text = dialog[0];
    }

    private void SwitchDialog()
    {
        dialogText.text = dialog[numberReplic];
        if (Input.GetMouseButtonDown(0)) numberReplic++;
    }

    public void TurnOnDialog()
    {
        dialogWindow.SetActive(true);
    }

    public void TurnOffHint()
    {
        hintWindow.SetActive(false);
    }

    public void TurnOnHint(int index)
    {
        hintText.text = LangSystem.lng.Hint[index];
        hintWindow.SetActive(true);
    }

    void Update()
    {
        SystemControl.readDialog = dialogWindow.activeSelf;
        if (!dialogWindow.activeSelf) return;
        hintWindow.SetActive(false);
        switch (numberDialog)
        {
            case 0:
                SwitchDialog();
                if (numberReplic == dialog.Count)
                {
                    dialogWindow.SetActive(false);
                    hintText.text = LangSystem.lng.Hint[0];
                    hintWindow.SetActive(true);
                    numberDialog++;
                    LoadDialog();
                    numberReplic = 0;
                }
                break;
            case 1:
                SwitchDialog();
                if (numberReplic == dialog.Count)
                {
                    dialogWindow.SetActive(false);
                    hintText.text = LangSystem.lng.Hint[1];
                    hintWindow.SetActive(true);
                    numberDialog++;
                    LoadDialog();
                    numberReplic = 0;
                }
                break;
            case 2:
                SwitchDialog();
                if (numberReplic == dialog.Count)
                {
                    dialogWindow.SetActive(false);
                    numberDialog++;
                    LoadDialog();
                    numberReplic = 0;
                }
                break;
            case 3:
                SwitchDialog();
                if (numberReplic == dialog.Count)
                {
                    dialogWindow.SetActive(false);
                    hintText.text = LangSystem.lng.Hint[2];
                    hintWindow.SetActive(true);
                    numberDialog++;
                    LoadDialog();
                    numberReplic = 0;
                }
                break;
            case 4:
                SwitchDialog();
                if (numberReplic == dialog.Count)
                {
                    dialogWindow.SetActive(false);
                    hintText.text = LangSystem.lng.Hint[3];
                    hintWindow.SetActive(true);
                    numberDialog++;
                    LoadDialog();
                    numberReplic = 0;
                }
                break;
            case 5:
                SwitchDialog();
                if (numberReplic == dialog.Count)
                {
                    dialogWindow.SetActive(false);
                    hintText.text = LangSystem.lng.Hint[5];
                    hintWindow.SetActive(true);
                    numberDialog++;
                    LoadDialog();
                    numberReplic = 0;
                }
                break;
            case 6:
                SwitchDialog();
                if (numberReplic == dialog.Count)
                {
                    dialogWindow.SetActive(false);
                    hintText.text = LangSystem.lng.Hint[6];
                    hintWindow.SetActive(true);
                    numberDialog = 10;
                    LoadDialog();
                    numberReplic = 0;
                }
                break;
            case 7:
                SwitchDialog();
                if (numberReplic == dialog.Count)
                {
                    dialogWindow.SetActive(false);
                    hintText.text = LangSystem.lng.Hint[6];
                    hintWindow.SetActive(true);
                    numberDialog = 10;
                    LoadDialog();
                    numberReplic = 0;
                }
                break;
            case 8:
                SwitchDialog();
                if (numberReplic == dialog.Count)
                {
                    dialogWindow.SetActive(false);
                    hintText.text = LangSystem.lng.Hint[6];
                    hintWindow.SetActive(true);
                    numberDialog = 10;
                    LoadDialog();
                    numberReplic = 0;
                }
                break;
            case 10:
                SwitchDialog();
                if (numberReplic == dialog.Count)
                {
                    dialogWindow.SetActive(false);
                    numberReplic = 0;
                    SystemControl.educationOn = false;
                    SystemControl.startGame = true;
                    StartGame.allCard += 3;
                    GameObject.Find("Quad").GetComponent<ChangeCharacter>().Change();
                    gameObject.GetComponent<EndGame>().AllClear();
                    StartCoroutine(NewDialog());
                }
                break;
        }
    }

    private IEnumerator NewDialog()
    {
        yield return new WaitForSeconds(2f);
        gameObject.AddComponent<EnemyDialog>().dialogWindow = dialogWindow;
        Destroy(gameObject.GetComponent<EduDialog>());
    }
}
