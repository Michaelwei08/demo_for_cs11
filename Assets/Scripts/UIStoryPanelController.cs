using UnityEngine;

public class UIStoryPanelController : MonoBehaviour
{
    [SerializeField] private GameObject storyPanel;
    [SerializeField] private GameObject startButton;   // 新增

    public void ShowStoryPanel()
    {
        if (storyPanel != null)
            storyPanel.SetActive(true);

        if (startButton != null)
            startButton.SetActive(false);   // 隐藏按钮
    }

    public void HideStoryPanel()
    {
        if (storyPanel != null)
            storyPanel.SetActive(false);

        if (startButton != null)
            startButton.SetActive(true);   // 如果需要恢复按钮
    }

    public void ToggleStoryPanel()
    {
        if (storyPanel != null)
            storyPanel.SetActive(!storyPanel.activeSelf);
    }
}