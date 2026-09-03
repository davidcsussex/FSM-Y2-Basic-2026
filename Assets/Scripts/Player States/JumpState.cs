//This is a derived class of State
//This means it inherits fields and methods from State.cs


using UnityEngine;

public class JumpState : State
{
    float rotationSpeed;

    
    public JumpState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        Debug.Log("entering jumping state");

        player.sr.color = new Color(0.8f, 0.3f, 0.4f);  //change the sprite colour
    }

    public override void Exit()
    {
        //exit the jump state
    }

    public override void Update()
    {
        ReadInput();

        if (player.interactAction.IsPressed())
        {
            sm.ChangeState(sm.idleState);

        }

        if (player.moveAction.ReadValue<Vector2>().magnitude > 0.1f )
        {
            sm.ChangeState(sm.runState);
        }

        UIscript.ui.DrawText("*** This is the jumping state ***");
        UIscript.ui.DrawText("Press E to change to idle");
        UIscript.ui.DrawText("Press left/right arrows to change to move");

    }

    public override void FixedUpdate()
    {
        //Fixed Update 
    }
}
