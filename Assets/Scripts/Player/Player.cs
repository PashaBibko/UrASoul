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
}
