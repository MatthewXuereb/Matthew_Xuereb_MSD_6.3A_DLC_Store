using UnityEngine;

public class ToggleEmojis : MonoBehaviour
{
    [SerializeField]
    private GameObject _emojis;

    void Start()
    {
        if (GameData.emojisToggled)
        {
            _emojis.SetActive(true);
            _emojis.GetComponent<ChangeSprite>().spriteColor = GameData.emojiColour;
        }
    }
}
