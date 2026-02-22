using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 只保留这个别名即可（可选）
using Debug = UnityEngine.Debug;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("游戏开始，正在加载场景...");
        // SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("玩家点击了退出游戏");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        UnityEngine.Application.Quit();
#endif
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("按下了退出键");
            // 你也可以选择在这里直接退出：
            // QuitGame();
        }
    }
}