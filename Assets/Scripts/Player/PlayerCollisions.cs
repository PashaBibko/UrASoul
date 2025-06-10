using UnityEngine;

public partial class Player : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Gets the normal of the collision //
        Vector3 normal = collision.GetContact(0).normal;

        // If what the player collided with was an obstacle reloads the scene //
        if (collision.collider.CompareTag("Obstacle") && normal.z < -0.95)
        {
            SceneControl.Reload();
        }

        // If it is an interactable calls it's OnInteract function //
        if (collision.collider.CompareTag("Interactable"))
        {
            GameObject obj = collision.collider.gameObject;
            obj.GetComponent<Interactable>().OnInteract();
        }
    }
}
