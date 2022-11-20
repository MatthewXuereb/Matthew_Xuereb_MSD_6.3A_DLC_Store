using UnityEngine;

public class PrivacyPolicy : MonoBehaviour
{
    [SerializeField]
    private GameObject _privacyPanel;

    public void AcceptPolicy()
    {
        PlayerPrefs.SetInt("PrivacyPolicyAccept", 1);
        PlayerPrefs.Save();

        _privacyPanel.SetActive(false);
    }
}
