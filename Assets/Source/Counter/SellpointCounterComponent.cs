using System;
using UnityEngine;

public class SellpointCounterComponent : CounterComponent
{
    private Order order;

    [SerializeField]
    GameObject orderRendererPlane;

    [Header("Resources")]
    [SerializeField]
    private Sprite purplePotion;
    [SerializeField]
    private Sprite brownPotion;
    [SerializeField]
    private Sprite tealPotion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetOrder(OrderFactory.GenerateRandomOrder());
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
            if (pickedPotionComponent != null && order.targetPotionColour == pickedPotionComponent.PotionColour)
            {
                GameManager.Instance.currentScore += order.OrderScore(pickedPotionComponent.PotionColour);
            }
            Destroy(playerMovement.pickedUpObject);
            GameManager.Instance.hudManager.SetHUDInventoryIcon(IngredientColor.None);
            stateMachine.currentState = IdleState.Instance;
            RemoveOrder();
            
        }

    }

    public void SetOrder(Order order)
    {
        orderRendererPlane.SetActive(true);
        this.order = order;
        SpriteRenderer potionRenderer = orderRendererPlane.GetComponent<SpriteRenderer>();

        switch (order.targetPotionColour)
        {
            case PotionColour.Purple:
                potionRenderer.sprite = purplePotion;
                break;
            case PotionColour.Brown:
                potionRenderer.sprite = brownPotion;
                break;
            case PotionColour.Teal:
                potionRenderer.sprite = tealPotion;
                break;
        }
    }

    private void RemoveOrder()
    {
        orderRendererPlane.SetActive(false);
        order = null;
    }

}
