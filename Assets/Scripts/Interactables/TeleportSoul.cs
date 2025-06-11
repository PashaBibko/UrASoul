using UnityEngine;

public class TeleportSoul : Soul
{
    public override bool OnFixedUpdate()
    {
        return CONTINUE_AFTER_FUNCTION;
    }

    public override bool OnUpdate(ref int index)
    {
        // Updates the index depending on user input //
        if (Input.GetKeyDown(KeyCode.A)) { index++; }
        if (Input.GetKeyDown(KeyCode.D)) { index--; }

        // Makes the index wrap around if it has gone out of bounds //
        if (index < 0) { index = 4; }
        if (index > 4) { index = 0; }

        return STOP_AFTER_FUNCTION;
    }
}
