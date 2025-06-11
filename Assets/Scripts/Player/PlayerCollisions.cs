using Unity.VisualScripting;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    // Fowards the Unity function calls to the Collide() function //
    private void OnTriggerEnter(Collider other) => Collide(other, Vector3.zero);
    private void OnTriggerStay(Collider other) => Collide(other, Vector3.zero);
    private void OnCollisionEnter(Collision collision) => Collide(collision.collider, collision.GetContact(0).normal);
    private void OnCollisionStay(Collision collision) => Collide(collision.collider, collision.GetContact(0).normal);

    // Custom collide function to handle collisions with objects and triggers //
    private void Collide(Collider collider, Vector3 normal)
    {
        // If what the player collided with was an obstacle reloads the scene //
        if (collider.CompareTag("Obstacle") && normal.z < -0.95)
        {
            // Stops the player from dying if they have a soul active //
            if (m_CurrentSoul != null)
            {
                m_CurrentSoul = null;
                m_SoulText.text = "Current Soul: ";
                StartCoroutine(Phase());
                return;
            }

            SceneControl.Reload();
        }

        // If it is an interactable calls it's OnInteract function //
        if (collider.CompareTag("Interactable"))
        {
            GameObject obj = collider.gameObject;
            obj.GetComponent<Interactable>().OnInteract();
        }
    }
}
