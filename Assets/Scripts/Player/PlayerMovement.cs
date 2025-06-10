using System.Collections;
using System.ComponentModel.Design;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    // Member variables //
    int m_RowIndex = 2;

    // Trackers of player input //
    bool m_JumpQueued;

    // Trackers of the player state //
    bool m_Grounded;

    // Only instance of player with a getter //
    static Player s_Instance = null;
    public static Player Instance() => s_Instance;

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

        // Casts a ray downwards to check if grounded //
        m_Grounded = Physics.Raycast(transform.position, Vector3.down, 1.2f);

        // Calls Soul Update function (if it can) //
        if (m_CurrentSoul != null)
        {
            if (m_CurrentSoul.OnUpdate())
            {
                return;
            }
        }

        // Updates the index in the array //
        if (Input.GetKeyDown(KeyCode.A)) { m_RowIndex++; }
        if (Input.GetKeyDown(KeyCode.D)) { m_RowIndex--; }

        // Clamps the index to the bounds of the array //
        if (m_RowIndex < 0) { m_RowIndex = 0; }
        if (m_RowIndex > 4) { m_RowIndex = 4; }
    }

    private void FixedUpdate()
    {
        // Makes the player move constantly fowards //
        m_Body.AddForce(Vector3.forward * 50, ForceMode.Force);

        // Jumps if the player pressed SPACE and they are grounded //
        if (m_JumpQueued && m_Grounded)
        {
            m_Body.AddForce(Vector3.up * 350, ForceMode.Force);
        }

        // Sets the player to the correct lane //
        // TODO: Lerp between the things       //
        SetX(m_Rows[m_RowIndex]);

        // Doubles gravity when player is falling to make it feel more responsive //
        Vector3 vel = m_Body.velocity;
        if (vel.y < 0.0f) { Physics.gravity = new Vector3(0f, -25f, 0f); }
        else { Physics.gravity = new Vector3(0f, -10f, 0f); }
    }

    IEnumerator Phase()
    {
        yield return new WaitForSeconds(1);
    }
}
 