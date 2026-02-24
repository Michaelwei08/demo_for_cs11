using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStoryPanelController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject storyPanel;
    [SerializeField] private GameObject startButton;   // ����
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject titleText;

    [UnitHeaderInspectable("Scene")]
    [SerializeField] private string gameSceneName = "GameScene";


    private void Start()
    {
        if (continueButton != null)
            continueButton.SetActive(false);
        if (storyPanel != null)
            storyPanel.SetActive(false);
    }

    public void ShowStoryPanel()
    {
        if (storyPanel != null)
            storyPanel.SetActive(true);

        if (continueButton != null)
            continueButton.SetActive(true);

        if (titleText != null)
            titleText.SetActive(false);

        if (startButton != null)
            startButton.SetActive(false);   // ���ذ�ť

    }

    public void HideStoryPanel()
    {
        if (storyPanel != null)
            storyPanel.SetActive(false);

        if (continueButton != null)
            continueButton.SetActive(false);

        if (titleText != null)
            titleText.SetActive(true);

        if (startButton != null)
            startButton.SetActive(true);   // �����Ҫ�ָ���ť
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }

/*
    public void ToggleStoryPanel()
    {
        if (storyPanel != null)
            storyPanel.SetActive(!storyPanel.activeSelf);
    }
*/

}