using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private Image _backgroundImage;

    [SerializeField]
    private TMP_Dropdown _dropdown;
    [SerializeField]
    private Toggle _emojisToggle, _particlesToggle;

    [SerializeField]
    private Sprite[] _backgrounds;

    public void ChangeBackgroundImageOnValueChange()
    {
        int value = _dropdown.value;

        GameData.currentBackgroundImage = _backgrounds[value];
        _backgroundImage.sprite = GameData.currentBackgroundImage;
    }

    public void ToggleEmojis()
    {
        GameData.emojisToggled = _emojisToggle.isOn;
    }

    public void ToggleParticles()
    {
        GameData.particlesToggled = _particlesToggle.isOn;
    }
}
