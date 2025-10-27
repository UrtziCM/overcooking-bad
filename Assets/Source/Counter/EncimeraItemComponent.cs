using System.Runtime.CompilerServices;
using UnityEngine;

public class EncimeraItemComponent : CounterComponent
{
    public Vector3 attachPosition;

    public GameObject ItemOnTop { get; set; } = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Interact(Transform player)
    {
        PlayerMovement playerController = player.GetComponent<PlayerMovement>();
        StateMachine playerStatemachine = playerController.GetStateMachine();

        if (ItemOnTop != null) // There is an item on top
        {
            if (playerStatemachine.currentState == IdleState.Instance) // We are not carrying items
            {
                playerController.pickedUpObject = ItemOnTop;
                playerStatemachine.ChangeState(CarryingState.Instance);
                ItemOnTop = null;

                playerController.pickedUpObject.transform.position = Vector3.down * 100;
                GameManager.Instance.hudManager.SetIngredient(playerController.pickedUpObject.GetComponent<IngredientComponent>().ingredientColor);
                Debug.Log(ItemOnTop);
            }
        }
        else // No item on top
        {
            if (playerStatemachine.currentState == CarryingState.Instance)
            {
                ItemOnTop = playerController.pickedUpObject;
                playerController.pickedUpObject.transform.position = transform.TransformPoint(attachPosition);
                playerController.pickedUpObject = null;

                GameManager.Instance.hudManager.SetIngredient(IngredientColor.None);
                playerStatemachine.ChangeState(IdleState.Instance);

            }
        }

    }

    private void OnDrawGizmos()
    {
        if (ItemOnTop != null)
            Gizmos.color = Color.yellow;
        else
            Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position + attachPosition, 0.5f);
    }
}
