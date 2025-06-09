using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    // The current section of floor the player is on //

    private void LateUpdate()
    {
        // Finds the section of floor the player is currently on //
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, m_FloorMask))
        {
            // Finds the floor controller of the current section //
            GameObject floor = hit.collider.gameObject;
            Floor controller = floor.GetComponentInChildren<Floor>();

            // Tells the floor to spawn the next section (if not already) //
            controller.SpawnNext();
        }

        // Throws an assert (Unity Editor only) if a floor section was not found //
        else
        {
            Debug.LogAssertion("Player floor section could not be found");
        }
    }
}
