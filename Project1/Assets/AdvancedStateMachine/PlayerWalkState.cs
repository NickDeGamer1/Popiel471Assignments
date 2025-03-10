using UnityEngine;

public class PlayerWalkState : AbstractClass
{
    public override void EnterState(PlayerStateManager PSM)
    {
        PSM.animator2.SetInteger("State", 1);
        PSM.SetWalk();
    }

    public override void UpdateState(PlayerStateManager PSM)
    {
        //What are we doing during this state?
        PSM.MovePlayer(PSM.defaultSpeed);
        //On what conditions do we leave this state?
        if (PSM.movement.magnitude < 0.1)
        {
            PSM.SwitchState(PSM.idolState);
        } else if (PSM.IsSneaking)
        {
            PSM.SwitchState(PSM.sneakState);
        }
    }
}
