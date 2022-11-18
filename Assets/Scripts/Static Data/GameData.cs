using TMPro;
using UnityEngine;

public static class GameData
{
    public static int numOfCoins = 1000;
    public static TextMeshProUGUI coinsText;

    public static bool emojisToggled, particlesToggled = false;
    public static Color emojiColour;

    public static Sprite currentBackgroundImage;

    public static StoreItemData[] items = new StoreItemData[6]
    {
        new StoreItemData(0, "Background 2", 200),
        new StoreItemData(1, "Background 3", 200),
        new StoreItemData(2, "Background 4", 200),
        new StoreItemData(3, "Background 5", 200),

        new StoreItemData(4, "Emojis", 500),
        new StoreItemData(5, "Particles", 800)
    };
    
    public static void UpdateItems()
    {
        foreach (StoreItemData item in items)
            item.UpdateItem();
    }
}
