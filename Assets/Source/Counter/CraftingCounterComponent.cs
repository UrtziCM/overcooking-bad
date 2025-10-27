using UnityEngine;

public class CraftingCounterComponent : EncimeraItemComponent
{
    [SerializeField]
    GameObject potion;

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
            playerStateMachine.currentState = CookingState.Instance;
            GameManager.Instance.OpenMinigame(player, this);
        }

    }
    public void MinigameFinished()
    {
        ItemOnTop = Instantiate(potion, transform.TransformPoint(attachPosition), Quaternion.identity);
    }
}
