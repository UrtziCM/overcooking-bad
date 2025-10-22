using UnityEngine;

public interface IState
{
    void Enter();
    void Exit();
    void Update();
}

public class IdleState : IState
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

public class CarryingState : IState
{
    public void Enter()
    {

    }
    public void Exit()
    {

    }
    public void Update()
    {
        
    }
}

public class CookingState : IState
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

public class StateMachine
{
    public IState currentState;

    public void ChangeState(IState state)
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
