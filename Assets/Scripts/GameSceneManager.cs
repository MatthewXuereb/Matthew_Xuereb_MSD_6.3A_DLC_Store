using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    private Image _backgroundImage;

    [SerializeField]
    private bool _isStoreScene = false;
    [Tooltip("Ignore if nor in store scene"), SerializeField]
    private TextMeshProUGUI _coinsText;

    void Awake()
    {
        if (GameData.currentBackgroundImage != null)
            _backgroundImage.sprite = GameData.currentBackgroundImage;

        SetStoreData();
    }

    public void LoadSceneById(int id)
    {
        SceneManager.LoadScene(id, LoadSceneMode.Single);
    }

    public void SetStoreData()
    {
        if (_isStoreScene)
        {
            GameData.coinsText = _coinsText;

            _coinsText.text = GameData.numOfCoins.ToString();

            FirebaseStorageManager.DownloadManifest();
        }
    }
}
