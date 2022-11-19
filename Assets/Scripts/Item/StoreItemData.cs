using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItemData
{
    public string name;

    public int price;
    public bool bought = false;

    public string url;

    public TextMeshProUGUI titleText;

    public Button button;
    public TextMeshProUGUI buttonText;

    public Sprite backgroundImage = null;

    public StoreItemData(string name, int price)
    {
        this.name = name;
        this.price = price;
    }

    public void SetItem(TextMeshProUGUI titleText, Button button, TextMeshProUGUI buttonText)
    {
        this.titleText = titleText;
        this.button = button;
        this.buttonText = buttonText;

        UpdateItem();

        if (bought)
            SetToBought();
    }

    public void SetToBought()
    {
        buttonText.text = "Owned";

        button.interactable = false;
        ColorBlock colorBlock = button.colors;
        colorBlock.disabledColor = Color.gray;
        button.colors = colorBlock;

        if (!bought)
        {
            GameData.numOfCoins -= price;
            GameData.coinsText.text = GameData.numOfCoins.ToString();

            bought = true;
        }

        GameData.UpdateItems();
    }

    public void UpdateItem()
    {
        if (GameData.numOfCoins - price < 0 && !bought)
            button.interactable = false;
    }
}
