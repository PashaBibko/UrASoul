using UnityEngine;

public class GreedySoul : Soul
{
    public override bool OnFixedUpdate(Rigidbody body, bool grounded, bool jump)
    {
        return CONTINUE_AFTER_FUNCTION;
    }

    public override bool OnUpdate(ref int index)
    {
        return CONTINUE_AFTER_FUNCTION;
    }
}
