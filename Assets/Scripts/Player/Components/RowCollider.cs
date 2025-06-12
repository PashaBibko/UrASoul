using UnityEngine;

public class RowCollider : MonoBehaviour
{
    [SerializeField] LayerMask m_Mask;

    Vector3 m_Box = new(0.1f, 0.1f, 1f);

    // The row is clear if it is not colliding with anything //
    public bool IsRowClear() => !Physics.BoxCast(transform.position + (Vector3.up * 5), m_Box, Vector3.down, Quaternion.identity, 5f, m_Mask);
}
