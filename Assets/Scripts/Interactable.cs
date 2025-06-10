using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent m_Event;

    public void OnInteract()
    {
        // Invokes the event if it is valid //
        if (m_Event != null)
        {
            m_Event.Invoke();
        }
    }
}
