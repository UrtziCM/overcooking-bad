using UnityEngine;

public class CraftingCounterComponent : EncimeraItemComponent
{
    [SerializeField]
    GameObject potion;

    [SerializeField]
    CounterComponent counterLeft;
    [SerializeField]
    CounterComponent counterRight;

    GameObject itemOnTopLeft => counterLeft.GetComponent<EncimeraItemComponent>().ItemOnTop;
    GameObject itemOnTopRight => counterRight.GetComponent<EncimeraItemComponent>().ItemOnTop;

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
        StateMachine playerStateMachine = playerMovement.GetStateMachine();

        if (playerStateMachine.currentState == IdleState.Instance)
        {
            if (ItemOnTop != null)
            {
                base.Interact(player);
                return;
            }

            if (itemOnTopRight != null && itemOnTopLeft != null)
            {
                playerStateMachine.currentState = CookingState.Instance;
                GameManager.Instance.OpenMinigame(player, this);
            }
        }

    }
    public void MinigameFinished()
    {
        IngredientColor leftIngredientColor = itemOnTopLeft.GetComponent<IngredientComponent>().ingredientColor;
        IngredientColor rightIngredientColor = itemOnTopRight.GetComponent<IngredientComponent>().ingredientColor;

        ItemOnTop = Instantiate(potion, transform.TransformPoint(attachPosition), Quaternion.identity);
        ItemOnTop.GetComponent<PotionComponent>().PotionColour = (PotionColour)((byte)leftIngredientColor + (byte)rightIngredientColor);

        Destroy(itemOnTopRight);
        Destroy(itemOnTopLeft); 
    }
}
