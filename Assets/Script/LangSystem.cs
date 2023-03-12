using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LangSystem : MonoBehaviour
{
    private string json;

    public static lang lng = new lang();

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Languages"))
        {
            PlayerPrefs.SetString("Languages", "ru_RU");
        }
        else
            switch (PlayerPrefs.GetString("Languages"))
            {
                case ("ru_RU"):
                    PlayerPrefs.SetString("Languages", "ru_RU");
                    break;
            }

        LangLoad();
    }

    void LangLoad()
    {
        json = File.ReadAllText(Application.streamingAssetsPath + "/Language/" + PlayerPrefs.GetString("Languages") + ".json");
        lng = JsonUtility.FromJson<lang>(json);
    }

    public void Update()
    {
        LangLoad();
    }

}

public class lang
{
    public string[] CardName = new string[14];
    public string[] CardDiscription = new string[14];
    public string[] StartDialog = new string[18];
    public string[] FirstLesson = new string[7];
    public string[] SecondLesson = new string[5];
    public string[] SecondLesson_2 = new string[2];
    public string[] ThirdLesson = new string[6];
    public string[] ForthLesson = new string[12];
    public string[] FifthLessonWin = new string[11];
    public string[] FifthLessonLose = new string[10];
    public string[] FifthLesson = new string[9];
    public string[] SixthLesson = new string[5];
    public string[] AboutAttack = new string[4];
    public string[] AboutProtect = new string[5];
    public string[] AboutAngel = new string[4];
    public string[] AboutDemonFromCreature = new string[7];
    public string[] AboutDemonFromHenchmen = new string[7];
    public string[] Hint = new string[7];
    public string[] Henchmen = new string[3];

    public Dictionary<int, string[]> eduDialog = new Dictionary<int, string[]>();
    public Dictionary<int, string[]> aboutCard = new Dictionary<int, string[]>();

    public lang()
    {
        eduDialog.Add(0, StartDialog);
        eduDialog.Add(1, FirstLesson);
        eduDialog.Add(2, SecondLesson);
        eduDialog.Add(3, SecondLesson_2);
        eduDialog.Add(4, ThirdLesson);
        eduDialog.Add(5, ForthLesson);
        eduDialog.Add(6, FifthLessonWin);
        eduDialog.Add(7, FifthLessonLose);
        eduDialog.Add(8, FifthLesson);
        eduDialog.Add(9, SixthLesson);

        aboutCard.Add(0, AboutAttack);
        aboutCard.Add(1, AboutProtect);
        aboutCard.Add(2, AboutAngel);
        aboutCard.Add(3, AboutDemonFromCreature);
        aboutCard.Add(4, AboutDemonFromHenchmen);
    }
}