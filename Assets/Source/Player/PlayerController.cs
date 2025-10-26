using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private StateMachine stateMachine = new();

    [Header("Input")]
    [SerializeField]
    private InputAction interactAction;
    [SerializeField]
    private InputAction moveAction;

    [Space(10)]
    [Header("Interaction")]
    [SerializeField]
    private float InteractDistance = 1.5f;
    [SerializeField]
    private LayerMask interactLayerMask;
    private GameObject targetedItem;
    private GameObject pickedUpObject;


    [Space(10)]
    [Header("Movement")]
    public GameObject cameraChild;
    private Vector2 moveDirection => moveAction.ReadValue<Vector2>();
    [SerializeField]
    float speed = 10f;
    [SerializeField]
    float sensitivity = 1f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stateMachine.ChangeState(IdleState.Instance);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        interactAction.Enable();
        moveAction.Enable();

        interactAction.performed += Interact;

    }

    // Update is called once per frame
    void Update()
    {
        if (stateMachine.currentState == CookingState.Instance)
            return;

        cameraChild.transform.eulerAngles += sensitivity * new Vector3(x: -Input.GetAxis("Mouse Y"), y: Mathf.Clamp(Input.GetAxis("Mouse X"), -90, 90), z: 0);
        Vector3 direction = cameraChild.transform.TransformDirection(moveDirection.x, 0, moveDirection.y);
        direction.y = 0;
        transform.position += speed * Time.deltaTime * (direction.normalized);



    }

    private void FixedUpdate()
    {
        if (!(Time.frameCount % 5 == 0))
            return;
        if (Physics.Raycast(cameraChild.transform.position, cameraChild.transform.forward, out RaycastHit raycastHit, InteractDistance, interactLayerMask))
        {
            targetedItem = raycastHit.transform.gameObject;
        }
        else
        {
            targetedItem = null;
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (!targetedItem) // Targeted item is null
            return;

        if (targetedItem.CompareTag("Ingredient"))
        {
            pickedUpObject = targetedItem;
            stateMachine.ChangeState(CarryingState.Instance);
            targetedItem.transform.position = Vector3.down * 100;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(cameraChild.transform.position, cameraChild.transform.forward * InteractDistance);
    }
}
