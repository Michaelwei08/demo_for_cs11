using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KnifeStabTrigger : MonoBehaviour
{
    [Header("Trigger")]
    [SerializeField] private string knifeTag = "Knife";
    [SerializeField] private GameObject noteObject;

    [Header("Phone UI")]
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private GameObject timeTextObject;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip successClip;

    private bool hasTriggered = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (hasTriggered) return;

        if (collision.gameObject.CompareTag(knifeTag))
        {
            TriggerProgress();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.gameObject.CompareTag(knifeTag))
        {
            TriggerProgress();
        }
    }

    private void TriggerProgress()
    {
        hasTriggered = true;

        if (noteObject != null)
            noteObject.SetActive(true);

/*        if (blackScreen != null)
            blackScreen.SetActive(false);
            */

        if (timeTextObject != null)
            timeTextObject.SetActive(true);

        if (audioSource != null && successClip != null)
            audioSource.PlayOneShot(successClip);
    }
}