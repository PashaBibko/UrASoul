using UnityEngine;

public class TutorialSection : MonoBehaviour
{
    [SerializeField] Canvas m_InstructionsCanvas;
    [SerializeField] KeyCode[] m_RequiredKeys;

    private void Start()
    {
        m_InstructionsCanvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0.0f;
            m_InstructionsCanvas.enabled = true;
        }
    }

    private void Update()
    {
        foreach (KeyCode key in m_RequiredKeys)
        {
            if (Input.GetKeyDown(key))
            {
                Time.timeScale = 1.0f;
                m_InstructionsCanvas.enabled = false;

                return;
            }
        }
    }
}
