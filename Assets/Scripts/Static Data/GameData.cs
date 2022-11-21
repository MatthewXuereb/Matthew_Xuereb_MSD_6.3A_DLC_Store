using TMPro;
using UnityEngine;
using System.Collections.Generic;

public static class GameData
{
    public static int numOfCoins = 1000;
    public static TextMeshProUGUI coinsText;

    public static bool emojisToggled, particlesToggled = false;
    public static Color emojiColour;

    public static Sprite currentBackgroundImage;

    public static Dictionary<string, StoreItemData> items = new Dictionary<string, StoreItemData>(6)
    {
        { "Emoji", new StoreItemData("Item", 0) },
        { "Particles", new StoreItemData("Item", 0) },

        { "Background 2", new StoreItemData("Item", 0) },
        { "Background 3", new StoreItemData("Item", 0) },
        { "Background 4", new StoreItemData("Item", 0) },
        { "Background 5", new StoreItemData("Item", 0) }
    };
    
    public static void UpdateItems()
    {
        items["Background 2"].UpdateItem();
        items["Background 3"].UpdateItem();
        items["Background 4"].UpdateItem();
        items["Background 5"].UpdateItem();

        items["Emoji"].UpdateItem();
        items["Particles"].UpdateItem();
    }
}
