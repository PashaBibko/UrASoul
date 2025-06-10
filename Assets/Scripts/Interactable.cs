using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent m_Event;

    // Invokes the event if it is valid //
    public void OnInteract() => m_Event?.Invoke();
}
