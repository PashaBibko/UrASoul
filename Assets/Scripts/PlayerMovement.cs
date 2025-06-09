using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody m_Body;

    [Header("Floor sections")]
    [SerializeField] GameObject m_StartFloorObject;
    [SerializeField] GameObject[] m_FloorObjects;

    // Member variables //
    float m_Force = 0;

    private void Update()
    {
        m_Force = Input.GetAxisRaw("Horizontal");
    }

    private void LateUpdate()
    {
        Vector3 v = m_Body.velocity;
        v.x = m_Force;
        v.z = 10.0f;

        m_Body.velocity = v;
    }
}
