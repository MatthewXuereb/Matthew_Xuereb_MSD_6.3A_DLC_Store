using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
    [SerializeField]
    private int _price;

    private bool _bought = false;

    [SerializeField]
    private string _title;

    [SerializeField]
    private TextMeshProUGUI _titleText, _buttonText;

    [SerializeField]
    private Button _button;

    private void Start()
    {
        _titleText.text = _title;
        _buttonText.text = _price.ToString();
    }

    private void Update()
    {
        if (StoreSceneData.numOfCoins - _price < 0 && !_bought)
        {
            _button.interactable = false;
        }
    }

    public void BuyItemOnClick()
    {
        if (StoreSceneData.numOfCoins - _price >= 0)
        {
            _buttonText.text = "Owned";
            _bought = true;

            _button.interactable = false;
            ColorBlock colorBlock = _button.colors;
            colorBlock.disabledColor = Color.gray;
            _button.colors = colorBlock;

            StoreSceneData.numOfCoins -= _price;
            StoreSceneData.coinsText.text = StoreSceneData.numOfCoins.ToString();
        }
    }
}
