using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    private Image _backgroundImage;

    [Tooltip("Ignore if nor in store scene"), SerializeField]
    private TextMeshProUGUI _coinsText;

    void Awake()
    {
        if (GameData.currentBackgroundImage != null)
            _backgroundImage.sprite = GameData.currentBackgroundImage;

        SetWelcomeScene();
        SetStoreData();
    }

    public void LoadSceneById(int id)
    {
        SceneManager.LoadScene(id, LoadSceneMode.Single);
    }

    public void SetWelcomeScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (!PlayerPrefs.HasKey("Id"))
            {
                string id = Guid.NewGuid().ToString();

                PlayerPrefs.SetString("Id", id);
                PlayerPrefs.Save();
            }
        }
    }

    public void SetStoreData()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            GameData.coinsText = _coinsText;

            _coinsText.text = GameData.numOfCoins.ToString();

            FirebaseStorageManager.DownloadManifest();
        }
    }
}
