using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    private int _i = 0;

    [SerializeField] 
    private float _timeLife = 1.0f;
    private float _preTime = 0.0f;

    [SerializeField] 
    private SpriteRenderer _spriteRenderer;

    public Color spriteColor;

    private Sprite[] _spritesArray;

    void Start()
    {
        _spritesArray = Resources.LoadAll<Sprite>("Sprites/Face Emojis Tilemap");

        _spriteRenderer.sprite = _spritesArray[_i];
        _spriteRenderer.color = spriteColor;
    }

    private void Update()
    {
        if (Time.time - _preTime > _timeLife)
        {
            _preTime = Time.time;

            _i++;
            if (_i > _spritesArray.Length - 1)
                _i = 0;

            _spriteRenderer.sprite = _spritesArray[_i];
        }
    }
}
