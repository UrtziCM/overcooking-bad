using UnityEngine;

public class TrashCounterComponent : CounterComponent
{
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
        StateMachine stateMachine = player.GetComponent<PlayerMovement>().GetStateMachine();

        if ((stateMachine.currentState == CarryingState.Instance))
        {
            Destroy(playerController.pickedUpObject);
            playerController.pickedUpObject = null;
            stateMachine.ChangeState(IdleState.Instance);
            GameManager.Instance.hudManager.SetIngredient(IngredientColor.None);
        }
    }
}
