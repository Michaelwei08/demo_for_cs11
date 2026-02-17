using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;         // 引起冲突的库（保留它，以防你以后需要用）
using UnityEngine;
using UnityEngine.SceneManagement; // 处理场景切换必备
using static System.Net.Mime.MediaTypeNames;
// --- 核心修复：给编译器下达死命令 ---
using Debug = UnityEngine.Debug;

public class MainMenuController : MonoBehaviour
{
    // 假设你的第 30 行在这里
    public void StartGame()
    {
        // 现在这里不会再报错了，编译器明确知道这是 UnityEngine 的 Debug
        Debug.Log("游戏开始，正在加载场景...");

        // 示例：加载索引为 1 的场景
        // SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("玩家点击了退出游戏");

        // 如果是编辑器模式
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void Update()
    {
        // 之前报错的第 30 行可能在这个位置
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("按下了退出键");
        }
    }
}