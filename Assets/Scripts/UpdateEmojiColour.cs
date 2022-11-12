using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateEmojiColour : MonoBehaviour
{
    [SerializeField]
    private Slider _redSlider, _greenSlider, _blueSlider;

    [SerializeField]
    private TextMeshProUGUI _redSliderText, _greenSliderText, _blueSliderText;

    [SerializeField]
    private RawImage _image;

    public void UpdateEmojiColourOnValueUpdate()
    {
        float redValue = _redSlider.value;
        float greenValue = _greenSlider.value;
        float blueValue = _blueSlider.value;

        _redSliderText.text = "R: " + Mathf.FloorToInt(redValue * 255).ToString();
        _greenSliderText.text = "G: " + Mathf.FloorToInt(greenValue * 255).ToString();
        _blueSliderText.text = "B: " + Mathf.FloorToInt(blueValue * 255).ToString();

        Color emojiColour = new Color(redValue, greenValue, blueValue);
        _image.color = emojiColour;

        GameData.emojiColour = emojiColour;
    }
}
