using TMPro;
using UnityEngine;

public class SetStoreSceneData : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _coinsText;

    void Awake()
    {
        GameData.coinsText = _coinsText;

        _coinsText.text = GameData.numOfCoins.ToString();
    }
}
