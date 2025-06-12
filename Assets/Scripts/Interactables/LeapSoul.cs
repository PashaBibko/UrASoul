using UnityEngine;

public class LeapSoul : Soul
{
    public override bool OnFixedUpdate(Rigidbody body, bool grounded, bool jump)
    {
        if (grounded && jump)
        {
            body.AddForce(Vector3.up * 500, ForceMode.Force);
        }

        return STOP_AFTER_FUNCTION;
    }

    public override bool OnUpdate(ref int index)
    {
        return CONTINUE_AFTER_FUNCTION;
    }
}
