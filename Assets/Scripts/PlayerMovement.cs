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

    // Trackers of player input //
    bool m_JumpQueued;

    // Trackers of the player state //
    bool m_Grounded;

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
        // Assigns it to the global instance //
        // If there is another instance throws an error (only in Unity and not builds) //
        Debug.Assert(s_Instance == null, "Multiple player instances", this);
        s_Instance = this;
    }

    private void Update()
    {
        // Checks user input //
        m_JumpQueued = Input.GetKey(KeyCode.Space);

        // Updates the index in the array //
        if (Input.GetKeyDown(KeyCode.A)) { m_RowIndex++; }
        if (Input.GetKeyDown(KeyCode.D)) { m_RowIndex--; }

        // Clamps the index to the bounds of the array //
        if (m_RowIndex < 0) { m_RowIndex = 0; }
        if (m_RowIndex > 4) { m_RowIndex = 4; }

        // Casts a ray downwards to check if grounded //
        m_Grounded = Physics.Raycast(transform.position, Vector3.down, 1.2f);
    }

    private void LateUpdate()
    {
        // Makes the player move constantly fowards //
        m_Body.AddForce(Vector3.forward * 10, ForceMode.Force);

        // Jumps if the player pressed SPACE and they are grounded //
        if (m_JumpQueued && m_Grounded)
        {
            m_Body.AddForce(Vector3.up * 80, ForceMode.Force);
        }

        // Sets the player to the correct lane //
        // TODO: Lerp between the things       //
        SetX(m_Rows[m_RowIndex]);
    }
}
 