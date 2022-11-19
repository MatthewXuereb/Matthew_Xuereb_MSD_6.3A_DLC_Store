using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{
    [SerializeField]
    private string name;

    [Header("Title"), SerializeField]
    private TextMeshProUGUI titleText;

    [Header("Button"), SerializeField]
    private Button button;
    [SerializeField]
    private TextMeshProUGUI buttonText;

    void Awake()
    {
        GameData.items[name].button = button;
        GameData.items[name].buttonText = buttonText;

        GameData.items[name].SetItem(titleText, button, buttonText);
    }

    public void BuyItemOnClick()
    {
        GameData.items[name].SetToBought();
    }

    public void BuyImageItemOnClick()
    {
        GameData.items[name].SetToBought();

        FirebaseStorageManager.DownloadImage(name);
    }
}
