using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{
    [SerializeField]
    private int id;

    [Header("Title"), SerializeField]
    private TextMeshProUGUI titleText;

    [Header("Button"), SerializeField]
    private Button button;
    [SerializeField]
    private TextMeshProUGUI buttonText;

    void Awake()
    {
        GameData.items[id].titleText = titleText;

        GameData.items[id].button = button;
        GameData.items[id].buttonText = buttonText;

        GameData.items[id].SetItem(titleText, button, buttonText);
    }

    public void BuyItemOnClick()
    {
        GameData.items[id].SetToBought();
    }
}
