using UnityEngine;
using UnityEngine.UI;

public partial class Player : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody m_Body;
    [SerializeField] Collider m_Collider;

    [SerializeField] GameObject[] m_SimpleSections;

    [Header("Text")]
    [SerializeField] Text m_SoulText;
    [SerializeField] Text m_SpeedText;

    [Header("Layer masks")]
    [SerializeField] LayerMask m_FloorMask;

    [Header("Settings")]
    [SerializeField] int[] m_Rows;

    // Member variables //

    // The current soul the player is using (null if they are not using any) //
    public Soul m_CurrentSoul;

    // Functions to allow other scripts to interact with the player //
    public static void SetSoul(Soul soul)
    {
        // Updates the soul //
        s_Instance.m_CurrentSoul = soul;

        // Sets the display text to display the correct type //
        string typename = soul.GetType().ToString();
        s_Instance.m_SoulText.text = "Current Soul: " + typename;
    }
}
