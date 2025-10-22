using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    private Vector2 inputVector;
    private InputAction interactAction;
    [SerializeField]
    private float SPEED = 10f;

    private StateMachine stateMachine = new();

    private GameObject pickedItem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
        stateMachine.ChangeState(new IdleState());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementVector = new Vector3(inputVector.x, 0, inputVector.y);
        characterController.Move(movementVector * SPEED * Time.deltaTime);
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
    }

    public void Interact(InputAction.CallbackContext context)
    {

    }
}
