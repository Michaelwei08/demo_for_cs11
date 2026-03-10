using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasscodeLock : MonoBehaviour
{
    [Header("Digit Displays")]
    [SerializeField] private TMP_Text digitText1;
    [SerializeField] private TMP_Text digitText2;
    [SerializeField] private TMP_Text digitText3;
    [SerializeField] private TMP_Text digitText4;

    [Header("Correct Code")]
    [SerializeField] private int correct1 = 1;
    [SerializeField] private int correct2 = 2;
    [SerializeField] private int correct3 = 4;
    [SerializeField] private int correct4 = 9;

    [Header("Unlock Target")]
    [SerializeField] private DrawerUnlock targetDrawerUnlock;
    [SerializeField] private GameObject keyObject;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip successClip;

    private int digit1 = 0;
    private int digit2 = 0;
    private int digit3 = 0;
    private int digit4 = 0;

    private bool unlocked = false;

    private void Start()
    {
        UpdateDisplay();

        if (keyObject != null)
            keyObject.SetActive(false);
    }

    public void IncrementDigit1()
    {
        if (unlocked) return;
        digit1 = (digit1 + 1) % 10;
        UpdateDisplay();
        CheckCode();
    }

    public void IncrementDigit2()
    {
        if (unlocked) return;
        digit2 = (digit2 + 1) % 10;
        UpdateDisplay();
        CheckCode();
    }

    public void IncrementDigit3()
    {
        if (unlocked) return;
        digit3 = (digit3 + 1) % 10;
        UpdateDisplay();
        CheckCode();
    }

    public void IncrementDigit4()
    {
        if (unlocked) return;
        digit4 = (digit4 + 1) % 10;
        UpdateDisplay();
        CheckCode();
    }

    private void UpdateDisplay()
    {
        if (digitText1 != null) digitText1.text = digit1.ToString();
        if (digitText2 != null) digitText2.text = digit2.ToString();
        if (digitText3 != null) digitText3.text = digit3.ToString();
        if (digitText4 != null) digitText4.text = digit4.ToString();
    }

    private void CheckCode()
    {
        if (digit1 == correct1 &&
            digit2 == correct2 &&
            digit3 == correct3 &&
            digit4 == correct4)
        {
            Unlock();
        }
    }

    private void Unlock()
    {
        if (unlocked) return;
        unlocked = true;

        if (targetDrawerUnlock != null)
            targetDrawerUnlock.UnlockDrawer();

        if (keyObject != null)
            keyObject.SetActive(true);

        if (audioSource != null && successClip != null)
            audioSource.PlayOneShot(successClip);
    }
}