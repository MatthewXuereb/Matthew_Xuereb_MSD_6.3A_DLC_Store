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
}
