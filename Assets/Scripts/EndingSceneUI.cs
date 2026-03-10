using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneUI : MonoBehaviour
{
    [SerializeField] private string startSceneName = "StarterScene";

    public void RestartGame()
    {
        SceneManager.LoadScene(startSceneName);
    }
}