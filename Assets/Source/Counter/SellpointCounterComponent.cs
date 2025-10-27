using UnityEngine;

public class SellpointCounterComponent : CounterComponent
{
    Order order = new(PotionColour.Purple);
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
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        StateMachine stateMachine = playerMovement.GetStateMachine();

        if (stateMachine.currentState == CarryingState.Instance)
        {
            PotionComponent pickedPotionComponent = playerMovement.pickedUpObject.GetComponent<PotionComponent>();
            if (pickedPotionComponent != null)
            {
                // GameManager.Instance.currentScore += order.OrderScore(pickedPotionComponent.PotionColour);
            }
            Destroy(playerMovement.pickedUpObject);
            stateMachine.currentState = IdleState.Instance;
        }

    }
}
