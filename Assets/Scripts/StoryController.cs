using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

using Image = UnityEngine.UI.Image;
using Debug = UnityEngine.Debug;

public class StoryController : MonoBehaviour
{
    [Header("UI 引用")]
    public GameObject storyPanel;   // 新增
    public Image displayImage;
    public TextMeshProUGUI storyText;

    [Header("剧情配置")]
    public Sprite[] backgroundSprites;

    [TextArea(3, 10)]
    public string[] storySentences;

    private int currentIndex = -1;   // 关键：从 -1 开始
    private bool storyStarted = false;

    void Start()
    {
        storyPanel.SetActive(false);   // 一开始隐藏
    }

    public void NextStep()
    {
        // 第一次点击：打开面板
        if (!storyStarted)
        {
            storyStarted = true;
            storyPanel.SetActive(true);
            currentIndex = 0;
            UpdateUI();
            return;
        }

        // 后续点击：翻页
        currentIndex++;

        if (currentIndex < backgroundSprites.Length &&
            currentIndex < storySentences.Length)
        {
            UpdateUI();
        }
        else
        {
            Debug.Log("剧情结束，进入游戏关卡...");
            SceneManager.LoadScene("GameScene");
        }
    }

    void UpdateUI()
    {
        displayImage.sprite = backgroundSprites[currentIndex];
        storyText.text = storySentences[currentIndex];

        Debug.Log($"当前播放到第 {currentIndex + 1} 页");
    }
}