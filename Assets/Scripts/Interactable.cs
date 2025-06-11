using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    UnityEvent m_Event;

    Interactable()
    {
        m_Event = new();
    }

    public void OnInteract() => m_Event?.Invoke();
    public void Add(UnityAction action) => m_Event.AddListener(action);
}
