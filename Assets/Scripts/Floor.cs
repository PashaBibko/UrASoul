using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject m_Start;
    [SerializeField] GameObject m_End;

    // Tracks wether it has already spawned the next obstacle //
    bool m_Spawned = false;

    // Holds a reference to the section of the floor that it creates //
    Floor m_Next;

    // Spawns the nect slope after this one //
    public void SpawnNext() 
    {
        // Doesn't try to spawn the next section if it has already //
        if (m_Spawned) { return; }
        m_Spawned = true;

        // Creates the next section //
        GameObject section = Instantiate(Player.RandomSlope(), new Vector3(0, 100, 0), Quaternion.identity);
        m_Next = section.GetComponentInChildren<Floor>();

        // Positions the next section correctly //
        Vector3 position = transform.position - new Vector3(0, 0, m_Next.CalculateStartLength());
        section.transform.position = position;

        // Rotates the section correctly because I set it up wrong and now CBA to fix it so I have to code more now ig //
        section.transform.localEulerAngles = new Vector3(0, 90, 0);
    }

    // Calculates the start length of this section //
    public float CalculateStartLength()
    {
        Vector3 offset = m_Start.transform.localPosition;
        return offset.x;
    }
}
