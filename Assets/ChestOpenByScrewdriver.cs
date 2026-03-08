using UnityEngine;

public class ChestOpenByScrewdriver : MonoBehaviour
{
    public Animator animator;
    public string screwdriverTag = "Screwdriver";
    bool opened = false;

    private void OnTriggerEnter(Collider other)
    {
        if (opened) return;

        if (other.CompareTag(screwdriverTag))
        {
            opened = true;
            animator.SetTrigger("Open");
        }
    }
}