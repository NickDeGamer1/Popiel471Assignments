using UnityEngine;

public class PlayerSneakState : AbstractClass
{
    public override void EnterState(PlayerStateManager PSM)
    {
        PSM.animator2.SetInteger("State", 2);
        PSM.SetSneak();
        //Debug.Log("I'm Sneaking");
    }

    public override void UpdateState(PlayerStateManager PSM)
    {
        //What are we doing during this state?
        PSM.MovePlayer(PSM.defaultSpeed * 0.5f);
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
