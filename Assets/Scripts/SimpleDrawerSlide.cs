/*
using UnityEngine;

public class SimpleDrawerSlide : MonoBehaviour
{
    [SerializeField] private bool unlocked = false;
    [SerializeField] private float minLocalZ = 0f;
    [SerializeField] private float maxLocalZ = 0.3f;

    private Vector3 startLocalPosition;

    private void Start()
    {
        startLocalPosition = transform.localPosition;
    }

    public void SetUnlocked(bool value)
    {
        unlocked = value;
    }

    private void Update()
    {
        if (!unlocked) return;

        Vector3 localPos = transform.localPosition;
        localPos.x = startLocalPosition.x;
        localPos.y = startLocalPosition.y;
        localPos.z = Mathf.Clamp(localPos.z, startLocalPosition.z + minLocalZ, startLocalPosition.z + maxLocalZ);
        transform.localPosition = localPos;
    }
}
*/

using UnityEngine;

public class SimpleDrawerSlide : MonoBehaviour
{
    public enum SlideAxis
    {
        X,
        Y,
        Z
    }

    [Header("Slide Settings")]
    [SerializeField] private bool unlocked = false;
    [SerializeField] private SlideAxis slideAxis = SlideAxis.Z;
    [SerializeField] private float minOffset = 0f;
    [SerializeField] private float maxOffset = 0.3f;

    private Vector3 startLocalPosition;

    private void Start()
    {
        startLocalPosition = transform.localPosition;
    }

    public void SetUnlocked(bool value)
    {
        unlocked = value;
    }

    private void Update()
    {
        if (!unlocked) return;

        Vector3 localPos = transform.localPosition;

        switch (slideAxis)
        {
            case SlideAxis.X:
                localPos.y = startLocalPosition.y;
                localPos.z = startLocalPosition.z;
                localPos.x = Mathf.Clamp(localPos.x,
                    startLocalPosition.x + minOffset,
                    startLocalPosition.x + maxOffset);
                break;

            case SlideAxis.Y:
                localPos.x = startLocalPosition.x;
                localPos.z = startLocalPosition.z;
                localPos.y = Mathf.Clamp(localPos.y,
                    startLocalPosition.y + minOffset,
                    startLocalPosition.y + maxOffset);
                break;

            case SlideAxis.Z:
                localPos.x = startLocalPosition.x;
                localPos.y = startLocalPosition.y;
                localPos.z = Mathf.Clamp(localPos.z,
                    startLocalPosition.z + minOffset,
                    startLocalPosition.z + maxOffset);
                break;
        }

        transform.localPosition = localPos;
    }
}