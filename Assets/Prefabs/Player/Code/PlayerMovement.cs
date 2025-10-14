using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputAction moveAction;
    [SerializeField]
    private float SPEED = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
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
