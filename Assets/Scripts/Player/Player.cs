using UnityEngine;
using UnityEngine.UI;

public partial class Player : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody m_Body;
    [SerializeField] Collider m_Collider;
    [SerializeField] Canvas m_DisplayCanvas;

    [SerializeField] GameObject[] m_SimpleSections;

    [Header("Text")]
    [SerializeField] Text m_SoulText;
    [SerializeField] Text m_SpeedText;
    [SerializeField] Text m_DisplayText;

    [Header("Layer masks")]
    [SerializeField] LayerMask m_FloorMask;

    [Header("Settings")]
    [SerializeField] int[] m_Rows;

    static bool s_FirstLoad = true;

    // Member variables //

    // The current soul the player is using (null if they are not using any) //
    public Soul m_CurrentSoul;

    // Functions to allow other scripts to interact with the player //
    public static void SetSoul(Soul soul)
    {
        s_Instance.gameObject.AddComponent(soul.GetType());
        s_Instance.m_CurrentSoul = (Soul)s_Instance.GetComponent(soul.GetType());

        // Sets the display text to display the correct type //
        string typename = soul.GetType().ToString();
        s_Instance.m_SoulText.text = "Current Soul: " + typename;

        Destroy(soul.transform.parent.gameObject);

        SoulTracker.PlayerCollected(soul.GetType());
    }

    public void DisplayCanvasWith(string message)
    {
        m_DisplayCanvas.enabled = true;
        m_DisplayText.text = message;
    }

    public void StopCanvasDisplay() => m_DisplayCanvas.enabled = false;
}
