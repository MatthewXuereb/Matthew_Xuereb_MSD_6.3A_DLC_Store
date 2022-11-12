using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class GameData
{
    public static int numOfCoins = 1000;

    public static Color emojiColour;

    public static bool backgroun2Bought, backgroun3Bought, backgroun4Bought, backgroun5Bought = false;
    public static bool emojisBought, particlesBought = false;

    public static bool emojisToggled, particlesToggled = false;

    public static Sprite currentBackgroundImage;

    public static TextMeshProUGUI coinsText;

    public static Item bgI2 = new Item();
    public static Item bgI3 = new Item();
    public static Item bgI4 = new Item();
    public static Item bgI5 = new Item();

    public static Item emojis = new Item();
    public static Item particles = new Item();

    public static void UpdateItems()
    {
        bgI2.UpdateItem();
        bgI3.UpdateItem();
        bgI4.UpdateItem();
        bgI5.UpdateItem();

        emojis.UpdateItem();
        particles.UpdateItem();
    }

    public class Item
    {
        public int price = 0;

        public bool bought = false;

        public Button button;
        public TextMeshProUGUI buttonText;

        public void SetItem(int price, Button button, TextMeshProUGUI buttonText)
        {
            this.price = price;
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
                numOfCoins -= price;
                coinsText.text = numOfCoins.ToString();

                bought = true;
            }

            UpdateItems();
        }

        public void UpdateItem()
        {
            if (numOfCoins - price < 0 && !bought)
            {
                button.interactable = false;
            }
        }
    }
}
