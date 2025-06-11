using UnityEngine;

public class BasicSoul : Soul
{
    public override bool OnFixedUpdate()
    {
        return CONTINUE_AFTER_FUNCTION;
    }

    public override bool OnUpdate(ref int index)
    {
        return CONTINUE_AFTER_FUNCTION;
    }
}
