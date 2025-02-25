using UnityEngine;

public class IdolState : AbstractClass
{
    public override void EnterState(PlayerStateManager PSM)
    {
        //Debug.Log("I'm Idoling");
    }

    public override void UpdateState(PlayerStateManager PSM)
    {
        //What are we doing during this state?
        //Nothing
        //On what conditions do we leave this state?
        if (PSM.movement.magnitude > 0.1)
        {
            PSM.SwitchState(PSM.walkState);
        }
    }
}
