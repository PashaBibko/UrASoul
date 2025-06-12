using System.Collections;
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
    public abstract bool OnFixedUpdate(Rigidbody body, bool grounded, bool jump);
}

public static class SoulTracker
{
    public class SoulState
    {
        public SoulState(System.Type type, string msg)
        {
            soulType = type;
            message = msg;
        }
        
        public System.Type soulType;
        public bool collected = false;
        public string message;
    }

    private static SoulState[] s_States =
    {
        new(typeof(GreedySoul), "Greedy soul doubles the ammount of coins you recive."),
        new(typeof(TeleportSoul), "Teleport soul allows you to teleport to the other side of the lanes by pressing A/D on the side"),
        new(typeof(LeapSoul), "Leap soul allows you to jump much higher (even on to tall obstacles)")
    };

    public static void PlayerCollected(System.Type soul)
    {
        foreach (SoulState state in s_States)
        {
            if (state.soulType == soul && state.collected == false)
            {
                state.collected = true;
                OnFirstCollectionOfType(state);
            }
        }
    }

    private static void OnFirstCollectionOfType(SoulState type)
    {
        float timeScale = Time.timeScale;
        Time.timeScale = 0.0f;

        Player.Instance().DisplayCanvasWith(type.message);
        Player.Instance().StartCoroutine(DisplayInfoCanvas(timeScale));
    }

    private static IEnumerator DisplayInfoCanvas(float storedTimeScale)
    {
        bool display = true;
        while (display)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            display = !Input.GetKey(KeyCode.Tab);
        }

        Player.Instance().StopCanvasDisplay();
        Time.timeScale = storedTimeScale;
    }
}
