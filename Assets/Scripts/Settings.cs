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
    private Sprite defualtBackground;

    public void ChangeBackgroundImageOnValueChange()
    {
        int value = _dropdown.value;

        switch (value)
        {
            case 1:
                if (GameData.items["Background 2"].bought) 
                    SetBackground(GameData.items["Background 2"].backgroundImage);
                break;
            case 2:
                if (GameData.items["Background 3"].bought)
                    SetBackground(GameData.items["Background 3"].backgroundImage);
                break;
            case 3:
                if (GameData.items["Background 4"].bought)
                    SetBackground(GameData.items["Background 4"].backgroundImage);
                break;
            case 4:
                if (GameData.items["Background 5"].bought)
                    SetBackground(GameData.items["Background 5"].backgroundImage);
                break;
            default:
                SetBackground(defualtBackground);
                break;
        }
    }
    private void SetBackground(Sprite background)
    {
        GameData.currentBackgroundImage = background;
        _backgroundImage.sprite = GameData.currentBackgroundImage;
    }

    public void ToggleEmojis()
    {
        if (GameData.items["Emoji"].bought)
            GameData.emojisToggled = _emojisToggle.isOn;
        else
            _emojisToggle.isOn = false;
    }

    public void ToggleParticles()
    {
        if (GameData.items["Particles"].bought)
            GameData.particlesToggled = _particlesToggle.isOn;
        else
            _particlesToggle.isOn = false;
    }
}
