using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private InputAction interactAction; 
    [SerializeField]
    private InputAction moveAction;

    private StateMachine stateMachine = new();

    private GameObject pickedItem;

    [SerializeField]
    float speed = 10.0f;

    private Vector2 moveDirection => moveAction.ReadValue<Vector2>();

    [SerializeField]
    float sensitivity = 1f;

    [SerializeField]
    public GameObject cameraChild;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stateMachine.ChangeState(new IdleState());

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        interactAction.Enable();
        moveAction.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        cameraChild.transform.eulerAngles += sensitivity * new Vector3(x: -Input.GetAxis("Mouse Y"), y: Mathf.Clamp(Input.GetAxis("Mouse X"), -90 , 90), z: 0);

        Vector3 direction = cameraChild.transform.TransformDirection(moveDirection.x, 0, moveDirection.y);
        direction.y = 0;
        transform.position += speed * Time.deltaTime * (direction.normalized);

    }

    public void Interact(InputAction.CallbackContext context)
    {

    }
}
