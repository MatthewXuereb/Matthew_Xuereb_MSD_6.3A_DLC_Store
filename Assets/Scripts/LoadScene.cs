using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadSceneById(int id)
    {
        SceneManager.LoadScene(id, LoadSceneMode.Single);
    }
}
