using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItemData
{
    public int id;
    public string name;

    public int price;
    public bool bought = false;

    public TextMeshProUGUI titleText;

    public Button button;
    public TextMeshProUGUI buttonText;

    public StoreItemData(int id, string name, int price)
    {
        this.id = id;
        this.name = name;
        this.price = price;
    }

    public void SetItem(TextMeshProUGUI titleText, Button button, TextMeshProUGUI buttonText)
    {
        this.titleText = titleText;
        this.button = button;
        this.buttonText = buttonText;

        this.titleText.text = name;
        this.buttonText.text = price.ToString();

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
