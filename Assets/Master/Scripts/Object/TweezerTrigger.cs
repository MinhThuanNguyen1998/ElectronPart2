using UnityEngine;

public class TweezerTrigger : MonoBehaviour
{
    [SerializeField] private MovingObjectByMouse m_MovingObjectByMouse;
    [SerializeField] private Transform m_ClampPoint;

    private void ClampSolid(Collider other)
    {
        if (!other.CompareTag("Solid")) return;
        Rigidbody rb = other.attachedRigidbody;
        if (rb == null) return;
        rb.isKinematic = true;
        rb.useGravity = false;
        other.transform.position = m_ClampPoint.position;
    }
    private void ReleaseSolid(Collider other)
    {
        if (!other.CompareTag("Solid")) return;
        Rigidbody rb = other.attachedRigidbody;
        if (rb == null) return;
        rb.isKinematic = false;
        rb.useGravity = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!m_MovingObjectByMouse.m_IsDragging) return;
        ClampSolid(other);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!m_MovingObjectByMouse.m_IsDragging) return;
        ClampSolid(other);
    }
    private void OnTriggerExit(Collider other)
    {
        ReleaseSolid(other);
    }
}
