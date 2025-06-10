using UnityEngine;

public partial class Player : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody m_Body;

    [SerializeField] GameObject[] m_SimpleSections;

    [Header("Layer masks")]
    [SerializeField] LayerMask m_FloorMask;

    [Header("Settings")]
    [SerializeField] int[] m_Rows;

    // Member variables //

    // The current soul the player is using (null if they are not using any) //
    Soul m_CurrentSoul;

    // Functions to allow other scripts to interact with the player //
    public static void SetSoul(Soul soul) => s_Instance.m_CurrentSoul = soul;
}
