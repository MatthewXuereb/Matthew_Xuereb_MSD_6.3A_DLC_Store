using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ToggleEmojis : MonoBehaviour
{
    [SerializeField] 
    private AssetReferenceGameObject _emojis;

    void Start()
    {
        if (GameData.emojisToggled)
        {
            _emojis.LoadAssetAsync<GameObject>().Completed +=
                (asyncOperationHandle) => {
                    if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                    {
                        GameObject emojiObject = Instantiate(asyncOperationHandle.Result);
                        emojiObject.GetComponent<ChangeSprite>().spriteColor = GameData.emojiColour;
                    }
                    else
                    {
                        Debug.LogError("Failed to load!");
                    }
                };
        }
    }
}
