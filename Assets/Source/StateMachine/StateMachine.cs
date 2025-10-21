using UnityEngine;

public interface Istate
{
    void Enter();
    void Exit();
    void Update();
}

public class IdleState : Istate
{
    public void Enter()
    {

    }
    public void Exit()
    {

    }
    public void Update()
    {
        //Idle
    }
}

public class HoldState : Istate
{
    public void Enter()
    {

    }
    public void Exit()
    {

    }
    public void Update()
    {
        //Hold
    }
}

public class InteractState : Istate
{
    public void Enter()
    {

    }
    public void Exit()
    {

    }
    public void Update()
    {
        //Interact
    }
}

public class StateMachine : MonoBehaviour
{
    public Istate currentState;

    public void ChangeState(Istate state)
    {
        currentState?.Exit();
        currentState = state;
        currentState.Enter();
    }

    public void Update()
    {
        currentState?.Update();
    }
}
