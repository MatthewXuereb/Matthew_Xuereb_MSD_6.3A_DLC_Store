using UnityEngine;

public class ToggleParticles : MonoBehaviour
{
    [SerializeField]
    private GameObject _particles;

    void Start()
    {
        if (GameData.particlesToggled)
        {
            _particles.SetActive(true);
        }
    }
}
