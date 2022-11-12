using UnityEngine;

public class BuyBackgroundImage : MonoBehaviour
{
    public void Buy(int i)
    {
        switch (i)
        {
            case 2:
                GameData.backgroun2Bought = true;
                break;
            case 3:
                GameData.backgroun3Bought = true;
                break;
            case 4:
                GameData.backgroun4Bought = true;
                break;
            case 5:
                GameData.backgroun5Bought = true;
                break;
            default:
                break;
        }
    }
}
