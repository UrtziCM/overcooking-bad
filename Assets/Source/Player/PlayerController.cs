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

    private GameObject targetedItem;

    [SerializeField]
    float speed = 10.0f;

    [SerializeField]
    private float InteractDistance = 1.5f;

    [SerializeField]
    private LayerMask interactLayerMask;

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

        interactAction.performed += Interact;

    }

    // Update is called once per frame
    void Update()
    {
        cameraChild.transform.eulerAngles += sensitivity * new Vector3(x: -Input.GetAxis("Mouse Y"), y: Mathf.Clamp(Input.GetAxis("Mouse X"), -90 , 90), z: 0);

        Vector3 direction = cameraChild.transform.TransformDirection(moveDirection.x, 0, moveDirection.y);
        direction.y = 0;
        transform.position += speed * Time.deltaTime * (direction.normalized);



    }

    private void FixedUpdate()
    {
        if (!(Time.frameCount % 5 == 0))
            return;
        RaycastHit raycastHit;
        if (Physics.Raycast(cameraChild.transform.position, cameraChild.transform.forward, out raycastHit, InteractDistance, interactLayerMask))
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
        Debug.Log($"Interacted with: {targetedItem}");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(cameraChild.transform.position, cameraChild.transform.forward * InteractDistance);
    }
}
