using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    private Image _backgroundImage;

    [SerializeField]
    private GameObject _privacyPanel;

    [Tooltip("Ignore if nor in store scene"), SerializeField]
    private TextMeshProUGUI _coinsText;

    void Start()
    {
        if (GameData.currentBackgroundImage != null)
            _backgroundImage.sprite = GameData.currentBackgroundImage;

        SetWelcomeScene();
        SetStoreData();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Backspace))
            PlayerPrefs.DeleteAll();
    }

    public void LoadSceneById(int id)
    {
        SceneManager.LoadSceneAsync(id, LoadSceneMode.Single);
    }
    public void LoadSceneByName(string name)
    {
        SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
    }

    public void SetWelcomeScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (PlayerPrefs.HasKey("PrivacyPolicyAccept"))
                if (PlayerPrefs.GetInt("PrivacyPolicyAccept") == 1)
                    _privacyPanel.SetActive(false);

            if (!PlayerPrefs.HasKey("Id"))
            {
                string id = Guid.NewGuid().ToString();

                PlayerPrefs.SetString("Id", id);
                PlayerPrefs.SetInt("PrivacyPolicyAccept", 0);
                PlayerPrefs.SetInt("NumOfCoins", GameData.numOfCoins);

                PlayerPrefs.Save();
            }
        }
    }

    public void SetStoreData()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            GameData.coinsText = _coinsText;
            GameData.numOfCoins = PlayerPrefs.GetInt("NumOfCoins");

            _coinsText.text = PlayerPrefs.GetInt("NumOfCoins").ToString();
            
            FirebaseStorageManager.DownloadManifest();
        }
    }
}
