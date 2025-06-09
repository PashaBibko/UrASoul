using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody m_Body;

    [Header("Settings")]
    [SerializeField] int[] m_Rows;
    [SerializeField] float m_FowardsForce;
    [SerializeField] float m_SideForce;

    // Member variables //
    int m_RowIndex = 2;

    // Only instance of player with a getter //
    static PlayerMovement s_Instance = null;
    public PlayerMovement Instance() => s_Instance;

    // Util helper functions to set positions //
    public void SetX(float val)
    {
        Vector3 p = m_Body.position;
        p.x = val;
        m_Body.position = p;
    }

    private void Start()
    {
        Debug.Assert(s_Instance == null, "Multiple player instances", this);
        s_Instance = this;
    }

    private void Update()
    {
        // Updates the index in the array //
        if (Input.GetKeyDown(KeyCode.A)) { m_RowIndex++; }
        if (Input.GetKeyDown(KeyCode.D)) { m_RowIndex--; }

        // Clamps the index to the bounds of the array //
        if (m_RowIndex < 0) { m_RowIndex = 0; }
        if (m_RowIndex > 4) { m_RowIndex = 4; }
    }

    private void LateUpdate()
    {
        // Makes the player move constantly fowards //
        Vector3 vel = m_Body.velocity;
        vel.z = 10f;
        m_Body.velocity = vel;

        // Sets the player to the correct lane //
        // TODO: Lerp between the things       //
        SetX(m_Rows[m_RowIndex]);
    }
}
 