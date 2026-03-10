using UnityEngine;

public class BoxUnlockTrigger : MonoBehaviour
{
    [Header("Key")]
    [SerializeField] private string requiredKeyTag = "Key";

    [Header("Objects to change")]
    [SerializeField] private GameObject lockVisual;
    [SerializeField] private GameObject boxLid;
    [SerializeField] private GameObject noteInside;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip successClip;

    private bool unlocked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (unlocked) return;

        if (other.CompareTag(requiredKeyTag))
        {
            UnlockBox();
        }
    }

    private void UnlockBox()
    {
        unlocked = true;

        if (lockVisual != null)
            lockVisual.SetActive(false);

        if (boxLid != null)
            boxLid.SetActive(false);

        if (noteInside != null)
            noteInside.SetActive(true);

        if (audioSource != null && successClip != null)
            audioSource.PlayOneShot(successClip);
    }
}