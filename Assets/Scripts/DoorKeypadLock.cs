using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DoorKeypadLock : MonoBehaviour
{
    [Header("Code")]
    [SerializeField] private string correctCode = "315726";
    [SerializeField] private int maxDigits = 6;

    [Header("UI")]
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private Image displayBox;
    [SerializeField] private Color defaultColor = Color.black;
    [SerializeField] private Color correctColor = Color.green;
    [SerializeField] private Color incorrectColor = Color.red;

    [Header("Scene")]
    [SerializeField] private string endingSceneName = "EndingScene";
    [SerializeField] private float successDelay = 1.0f;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonClip;
    [SerializeField] private AudioClip correctClip;
    [SerializeField] private AudioClip incorrectClip;

    private string currentInput = "";
    private bool lockedOut = false;

    private void Start()
    {
        ResetDisplay();
    }

    public void PressDigit(string digit)
    {
        if (lockedOut) return;
        if (currentInput.Length >= maxDigits) return;

        currentInput += digit;
        UpdateDisplayText();

        if (audioSource != null && buttonClip != null)
            audioSource.PlayOneShot(buttonClip);
    }

    public void PressClear()
    {
        if (lockedOut) return;

        currentInput = "";
        ResetDisplay();

        if (audioSource != null && buttonClip != null)
            audioSource.PlayOneShot(buttonClip);
    }

    public void PressEnter()
    {
        if (lockedOut) return;

        if (currentInput == correctCode)
        {
            StartCoroutine(HandleCorrectCode());
        }
        else
        {
            StartCoroutine(HandleIncorrectCode());
        }
    }

    private IEnumerator HandleCorrectCode()
    {
        lockedOut = true;

        if (displayBox != null)
            displayBox.color = correctColor;

        if (displayText != null)
            displayText.text = "CORRECT";

        if (audioSource != null && correctClip != null)
            audioSource.PlayOneShot(correctClip);

        yield return new WaitForSeconds(successDelay);

        SceneManager.LoadScene(endingSceneName);
    }

    private IEnumerator HandleIncorrectCode()
    {
        lockedOut = true;

        if (displayBox != null)
            displayBox.color = incorrectColor;

        if (displayText != null)
            displayText.text = "INCORRECT";

        if (audioSource != null && incorrectClip != null)
            audioSource.PlayOneShot(incorrectClip);

        yield return new WaitForSeconds(1.0f);

        currentInput = "";
        ResetDisplay();
        lockedOut = false;
    }

    private void UpdateDisplayText()
    {
        if (displayText != null)
            displayText.text = currentInput;
    }

    private void ResetDisplay()
    {
        if (displayBox != null)
            displayBox.color = defaultColor;

        if (displayText != null)
        {
            if (currentInput.Length == 0)
                displayText.text = "ENTER CODE";
            else
                displayText.text = currentInput;
        }
    }
}