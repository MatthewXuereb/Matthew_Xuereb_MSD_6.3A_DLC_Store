using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ToggleParticles : MonoBehaviour
{
    [SerializeField] 
    private AssetReferenceGameObject _particles;

    void Start()
    {
        if (GameData.particlesToggled)
        {
            _particles.LoadAssetAsync<GameObject>().Completed +=
                (asyncOperationHandle) => {
                    if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                    {
                        Instantiate(asyncOperationHandle.Result);
                    }
                    else
                    {
                        Debug.LogError("Failed to load!");
                    }
                };
        }
    }
}
