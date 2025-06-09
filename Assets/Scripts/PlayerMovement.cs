using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody m_Body;

    [Header("Settings")]
    [SerializeField] float m_FowardsForce;
    [SerializeField] float m_SideForce;

    // Member variables //
    float m_Force = 0;

    // Only instance of player with a getter //
    static PlayerMovement s_Instance = null;
    public PlayerMovement Instance() => s_Instance;

    private void Start()
    {
        Debug.Assert(s_Instance == null, "Multiple player instances", this);
        s_Instance = this;
    }

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
