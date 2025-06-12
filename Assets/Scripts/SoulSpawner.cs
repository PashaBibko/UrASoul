using UnityEngine;

public class SoulSpawner : MonoBehaviour
{
    // List of all the different types of souls //
    private static readonly System.Type[] m_SoulScripts =
    {
        typeof(GreedySoul),
        typeof(TeleportSoul),
        typeof(LeapSoul)
    };

    void Start()
    {
        // Adds a random soul type to the game object //
        int index = Random.Range(0, m_SoulScripts.Length);
        gameObject.AddComponent(m_SoulScripts[index]);
        Soul soul = null;

        // Loops over the types to find the generated soul //
        foreach (System.Type type in m_SoulScripts)
        {
            soul = (Soul)gameObject.GetComponent(type);

            if (soul != null) { break; }
        }

        // Adds the interact script //
        Interactable inter = gameObject.AddComponent<Interactable>();
        inter.Add(soul.OnInteractCollision);

        // Deletes the spawner script (this) //
        Destroy(this);
    }
}
