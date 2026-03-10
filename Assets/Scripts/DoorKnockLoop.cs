using UnityEngine;
using System.Collections;

public class DoorKnockLoop : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip knockClip;

    [Header("Timing")]
    [SerializeField] private float firstDelay = 10f;
    [SerializeField] private float repeatInterval = 30f;

    private Coroutine loopRoutine;

    private void Start()
    {
        loopRoutine = StartCoroutine(KnockLoop());
    }

    private IEnumerator KnockLoop()
    {
        yield return new WaitForSeconds(firstDelay);

        while (true)
        {
            if (audioSource != null && knockClip != null)
            {
                audioSource.PlayOneShot(knockClip);
            }

            yield return new WaitForSeconds(repeatInterval);
        }
    }
}