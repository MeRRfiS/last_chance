using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardProperties : MonoBehaviour
{
    [SerializeField]
    private int textIndex = 0;

    [Header("Properties")]
    [SerializeField]
    private int damage = 0;
    [SerializeField]
    private int protect = 0;
    [SerializeField]
    private int idEffect = 0;
    [SerializeField]
    private int price = 0;

    [Header("Images")]
    [SerializeField]
    private List<Sprite> typeImages = new List<Sprite>();
    [SerializeField]
    private Sprite cardImage;

    public Dictionary<string, int> properties = new Dictionary<string, int>();

    private Text _valueText;
    private Image _typeImage;
    private Image _cardImage;

    private void Awake()
    {
        _valueText = transform.GetChild(0).GetComponent<Text>();
        transform.GetChild(3).GetComponent<Text>().text = price.ToString();
        transform.GetChild(4).GetComponent<Text>().text = LangSystem.lng.CardName[textIndex];
        transform.GetChild(5).GetComponent<Text>().text = LangSystem.lng.CardDiscription[textIndex];
        _typeImage = transform.GetChild(2).GetComponent<Image>();
        _cardImage = transform.GetChild(1).GetComponent<Image>();
        _cardImage.sprite = cardImage;

        properties.Add("Damage", damage);
        properties.Add("Protect", protect);
        properties.Add("idEffect", idEffect);
        properties.Add("Price", price);

        switch (gameObject.tag)
        {
            case "Attack":
                _valueText.text = properties["Damage"].ToString();
                _typeImage.sprite = typeImages[0];
                break;
            case "Protect":
                _valueText.text = properties["Protect"].ToString();
                _typeImage.sprite = typeImages[1];
                break;
            default:
                _valueText.text = string.Empty;
                if(gameObject.tag == "Angel")
                    _typeImage.sprite = typeImages[2];
                else
                    _typeImage.sprite = typeImages[3];
                break;
        }
    }
}
