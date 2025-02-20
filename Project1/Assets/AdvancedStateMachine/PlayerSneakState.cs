using UnityEngine;

public class PlayerSneakState : AbstractClass
{
    public override void EnterState(PlayerStateManager PSM)
    {
        Debug.Log("I'm Sneaking");
    }

    public override void UpdateState(PlayerStateManager PSM)
    {
        PSM.MovePlayer(PSM.defaultSpeed/4);
        //What are we doing during this state?
        PSM.MovePlayer(20f);
        //On what conditions do we leave this state?
        if (PSM.movement.magnitude < 0.1)
        {
             PSM.SwitchState(PSM.idolState);
        }
        else
        {
            if (!PSM.IsSneaking)
                PSM.SwitchState(PSM.walkState);
        }
    }
}
