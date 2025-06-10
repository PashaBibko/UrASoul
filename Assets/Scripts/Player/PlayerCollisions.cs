using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // If what the player collided with was an obstacle reloads the scene //
        if (collision.collider.CompareTag("Obstacle"))
        {
            Debug.Log(collision.GetContact(0).normal);

            SceneControl.Reload();
        }
    }
}
