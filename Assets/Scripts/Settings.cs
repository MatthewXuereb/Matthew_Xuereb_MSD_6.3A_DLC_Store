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

        switch (value)
        {
            case 1:
                if (GameData.bgI2.bought) 
                    SetBackground(value);
                break;
            case 2:
                if (GameData.bgI3.bought)
                    SetBackground(value);
                break;
            case 3:
                if (GameData.bgI4.bought)
                    SetBackground(value);
                break;
            case 4:
                if (GameData.bgI5.bought)
                    SetBackground(value);
                break;
            default:
                break;
        }
    }
    private void SetBackground(int value)
    {
        GameData.currentBackgroundImage = _backgrounds[value];
        _backgroundImage.sprite = GameData.currentBackgroundImage;
    }

    public void ToggleEmojis()
    {
        if (GameData.emojisBought)
            GameData.emojisToggled = _emojisToggle.isOn;
        else
            _emojisToggle.isOn = false;
    }

    public void ToggleParticles()
    {
        if (GameData.particlesBought)
            GameData.particlesToggled = _particlesToggle.isOn;
        else
            _particlesToggle.isOn = false;
    }
}
