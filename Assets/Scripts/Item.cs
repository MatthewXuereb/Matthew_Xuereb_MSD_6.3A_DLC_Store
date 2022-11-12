using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField]
    private int price, id;

    [SerializeField]
    private Button button;
    [SerializeField]
    private TextMeshProUGUI buttonText;

    void Awake()
    {
        switch (id)
        {
            case 0:
                GameData.bgI2.SetItem(price, button, buttonText);
                break;
            case 1:
                GameData.bgI3.SetItem(price, button, buttonText);
                break;
            case 2:
                GameData.bgI4.SetItem(price, button, buttonText);
                break;
            case 3:
                GameData.bgI5.SetItem(price, button, buttonText);
                break;
            case 4:
                GameData.emojis.SetItem(price, button, buttonText);
                break;
            case 5:
                GameData.particles.SetItem(price, button, buttonText);
                break;
            default:
                break;
        }
    }

    public void BuyItemOnClick()
    {
        switch (id)
        {
            case 0:
                GameData.bgI2.SetToBought();
                GameData.backgroun2Bought = true;
                break;
            case 1:
                GameData.bgI3.SetToBought();
                GameData.backgroun3Bought = true;
                break;
            case 2:
                GameData.bgI4.SetToBought();
                GameData.backgroun4Bought = true;
                break;
            case 3:
                GameData.bgI5.SetToBought();
                GameData.backgroun5Bought = true;
                break;
            case 4:
                GameData.emojis.SetToBought();
                GameData.emojisBought = true;
                break;
            case 5:
                GameData.particles.SetToBought();
                GameData.particlesBought = true;
                break;
            default:
                break;
        }
    }
}
