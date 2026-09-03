
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;
using System.Collections;

public class IdleState : State
{
    // constructor
    public IdleState( PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        // this method is called when the state begins

        Debug.Log("entering idle state");
        player.sr.color = new Color(0.5f, 0.8f, 0.7f);
    }

    public override void Exit()
    {
        // this method is called when the state has finished
        Debug.Log("exiting idle state");

        //you should disable any running coroutines here
        player.StopAllCoroutines();
    }


    public override void Update()
    {
        if( player.moveAction.ReadValue<Vector2>().magnitude > 0.1f )
        {
            sm.ChangeState(sm.runState);
        }

        if (player.jumpAction.IsPressed())
        {
            sm.ChangeState(sm.jumpState);
        }


        //example of running a coroutine from a state and not directly from the monobehaviour
        if (player.crouchAction.IsPressed())
        {
            player.StartCoroutine( IdleCo() );
        }

        UIscript.ui.DrawText("*** This is the idle state ***");
        UIscript.ui.DrawText("Press space to change to jump");
        UIscript.ui.DrawText("Press left/right arrows to change to move");
        UIscript.ui.DrawText("Press c to start the coroutine");


    }

    public override void FixedUpdate()
    {
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
    }


    public IEnumerator IdleCo()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(2);
            Debug.Log("Coroutine step 1");

            yield return new WaitForSeconds(2);
            Debug.Log("Coroutine step 2");

            Debug.Log("Coroutine repeat " + (i+1));

        }
        yield break;
    }




}
