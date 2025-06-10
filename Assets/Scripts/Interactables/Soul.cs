using UnityEngine;

public abstract class Soul : MonoBehaviour
{
    // Lets the collision attach it to the player //
    public void OnInteractCollision() => Player.SetSoul(this);

    // Virtual function to allow for custom functionality per-soul when updated //
    public abstract bool OnUpdate();

    // Virtual function to allow for custom functionality per-soul on fixed updates //
    public abstract bool OnFixedUpdate();
}
