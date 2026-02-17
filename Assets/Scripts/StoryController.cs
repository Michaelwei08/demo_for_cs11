using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

// --- 解决命名空间冲突的核心修复 ---
using Image = UnityEngine.UI.Image;
using Debug = UnityEngine.Debug;

public class StoryController : MonoBehaviour
{
    [Header("UI 引用")]
    [Tooltip("用于显示背景图的 Image 组件")]
    public Image displayImage;

    [Tooltip("用于显示剧情文字的 TextMeshPro 组件")]
    public TextMeshProUGUI storyText;

    [Header("剧情配置")]
    [Tooltip("按顺序拖入你的 2D 背景插画")]
    public Sprite[] backgroundSprites;

    [Tooltip("按顺序输入每张图片对应的文字内容")]
    [TextArea(3, 10)] // 让编辑框变大，方便输入长句子
    public string[] storySentences;

    private int currentIndex = 0;

    void Start()
    {
        // 检查资源是否配置正确
        if (backgroundSprites.Length == 0 || storySentences.Length == 0)
        {
            Debug.LogError("请在 Inspector 面板中为 StoryController 添加图片和文字！");
            return;
        }

        // 初始化显示第一页
        UpdateUI();
    }

    void Update()
    {
        // 检测鼠标左键点击、空格键或 Enter 键翻页
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            NextStep();
        }
    }

    public void NextStep()
    {
        currentIndex++;

        // 如果还没播完，更新下一张
        if (currentIndex < backgroundSprites.Length && currentIndex < storySentences.Length)
        {
            UpdateUI();
        }
        else
        {
            // 剧情播完，跳转到真正的游戏关卡
            // 请确保 "GameScene" 这个名字与你 Build Settings 里的场景名一致
            Debug.Log("剧情结束，进入游戏关卡...");
            SceneManager.LoadScene("GameScene");
        }
    }

    void UpdateUI()
    {
        if (displayImage != null)
            displayImage.sprite = backgroundSprites[currentIndex];

        if (storyText != null)
            storyText.text = storySentences[currentIndex];

        Debug.Log($"当前播放到第 {currentIndex + 1} 页");
    }
}