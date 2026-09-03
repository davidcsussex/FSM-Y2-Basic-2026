
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;

public class RunState : State
{
    protected float speed;
    protected float rotationSpeed;

    public RunState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        speed = 3;
        base.Enter();
        horizontalInput = verticalInput = 0.0f;

        Debug.Log("entering running state");

        player.sr.color = new Color(0.8f, 0.8f, 0.2f);
    }

    public override void Exit()
    {
        base.Exit();
    }



    public override void Update()
    {

        TestMethod("hello");

        

        ReadInput();

        if (player.interactAction.IsPressed())
        {
            sm.ChangeState(sm.idleState);
        }

        if (player.jumpAction.IsPressed())
        {
            sm.ChangeState(sm.jumpState);
        }

        //debug move gameObject
        player.rb.linearVelocity = player.moveAction.ReadValue<Vector2>() * speed;


        UIscript.ui.DrawText("*** This is the running state ***");
        UIscript.ui.DrawText("Press E to change to idle");
        UIscript.ui.DrawText("Press space to change to jump");
        UIscript.ui.DrawText("Press left/right arrows to change to move");

    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided in runstate");

        if( collision.tag == "enemy")
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        }
    }
    public override void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit collision in runstate");

        if (collision.tag == "enemy")
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f);
        }
    }



    public override void FixedUpdate()
    {
    }
}
