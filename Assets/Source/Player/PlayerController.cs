using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction interactAction;
    [SerializeField]
    private float SPEED = 10f;

    private StateMachine stateMachine = new();

    private GameObject pickedItem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        interactAction = InputSystem.actions.FindAction("Interact");
        
        stateMachine.ChangeState(new IdleState());
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = moveAction.ReadValue<Vector2>();
        Vector3 movementVector = new Vector3(inputVector.x, 0, inputVector.y);
        if (movementVector != Vector3.zero)
        {
            transform.position = transform.position + (movementVector * SPEED) * Time.deltaTime;
            transform.LookAt(transform.position + movementVector);
            
        }
    }
}
