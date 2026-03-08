using UnityEngine;

public class DrawerSlide : MonoBehaviour
{
    public float minZ = 0f;
    public float maxZ = 0.35f;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        Vector3 pos = transform.localPosition;

        pos.x = startPos.x;
        pos.y = startPos.y;

        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.localPosition = pos;
    }
}