using TMPro;
using UnityEngine;

public class SetStoreSceneData : MonoBehaviour
{
    [SerializeField]
    private int _numOfCoins;

    [SerializeField]
    private TextMeshProUGUI _coinsText;

    void Awake()
    {
        StoreSceneData.numOfCoins = _numOfCoins;
        StoreSceneData.coinsText = _coinsText;

        _coinsText.text = _numOfCoins.ToString();
    }
}
