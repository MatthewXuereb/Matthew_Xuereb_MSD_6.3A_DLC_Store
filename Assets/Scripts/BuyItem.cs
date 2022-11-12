using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
    [SerializeField]
    private int _price, _id;

    private bool _bought;

    [SerializeField]
    private TextMeshProUGUI _buttonText;

    [SerializeField]
    private Button _button;

    private void Update()
    {
        if (GameData.numOfCoins - _price < 0 && !_bought)
        {
            _button.interactable = false;
        }
    }

    public void BuyItemOnClick()
    {
        if (GameData.numOfCoins - _price >= 0)
        {
            _buttonText.text = "Owned";
            _bought = true;

            _button.interactable = false;
            ColorBlock colorBlock = _button.colors;
            colorBlock.disabledColor = Color.gray;
            _button.colors = colorBlock;

            GameData.numOfCoins -= _price;
            GameData.coinsText.text = GameData.numOfCoins.ToString();
        }
    }
}
