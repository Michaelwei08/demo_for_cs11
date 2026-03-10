using UnityEngine;


public class DrawerUnlock : MonoBehaviour
{
    [Header("Grab")]
    [SerializeField] private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    [Header("Slide")]
    [SerializeField] private SimpleDrawerSlide drawerSlide;

    [Header("State")]
    [SerializeField] private bool unlocked = false;

    public bool IsUnlocked => unlocked;
    
    private void Start()
    {
        if (grabInteractable != null)
            grabInteractable.enabled = false;

        if (drawerSlide != null)
            drawerSlide.SetUnlocked(false);
    }

    public void UnlockDrawer()
    {
        unlocked = true;

        if (grabInteractable != null)
            grabInteractable.enabled = true;

        if (drawerSlide != null)
            drawerSlide.SetUnlocked(true);
    }
}