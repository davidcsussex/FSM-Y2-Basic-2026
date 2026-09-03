
//player.cs is the Monobehaviour and owns the Unity components
//It passes control to the statemachine

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public StateMachine sm;

    //define the actions
    public InputAction moveAction;
    public InputAction crouchAction;
    public InputAction jumpAction;
    public InputAction interactAction;



    private void Start()
    {
        sm = new StateMachine(this);
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();


        sm.Init(sm.idleState); //this will be the first state to run 

        //initialise the actions
        moveAction = InputSystem.actions.FindAction("Move");
        crouchAction = InputSystem.actions.FindAction("Crouch");
        interactAction = InputSystem.actions.FindAction("Interact");
        jumpAction = InputSystem.actions.FindAction("Jump");


    }

    private void Update()
    {
        //do not put any of your own methods here - they go in the individual state files
        sm.Update();

        UIscript.ui.DrawText("Current/last state: " + sm.currentState + "  " + sm.lastState);

    }

    private void FixedUpdate()
    {
        //do not put any of your own methods here - they go in the state files
        sm.FixedUpdate();
    }

    //add your additional collision handling here
    void OnCollisionEnter2D(Collision2D collision)
    {
        sm.currentState.OnCollisionEnter2D(collision);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        sm.currentState.OnTriggerEnter2D(collision);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        sm.currentState.OnTriggerExit2D(collision);
    }



}
