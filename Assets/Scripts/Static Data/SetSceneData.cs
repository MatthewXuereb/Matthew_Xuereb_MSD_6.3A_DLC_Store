using UnityEngine;
using UnityEngine.UI;

public class SetSceneData : MonoBehaviour
{
    [SerializeField]
    private Image _backgroundImage;

    void Awake()
    {
        if (GameData.currentBackgroundImage != null)
        {
            _backgroundImage.sprite = GameData.currentBackgroundImage;
        }
    }
}
