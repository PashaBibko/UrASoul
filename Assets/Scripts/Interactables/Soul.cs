using UnityEngine;

public abstract class Soul : MonoBehaviour
{
    // Lets the collision attach it to the player //
    public void OnInteractCollision() => Player.SetSoul(this);

    public const bool CONTINUE_AFTER_FUNCTION = false;
    public const bool STOP_AFTER_FUNCTION = true;

    // Virtual function to allow for custom functionality per-soul when updated //
    public abstract bool OnUpdate(ref int index);

    // Virtual function to allow for custom functionality per-soul on fixed updates //
    public abstract bool OnFixedUpdate();
}
