using System.Collections.Generic;
using UnityEngine;

public enum IngredientColor : byte
{
    Red,
    Green,
    Blue,
    None = 255
}

public class IngredienteraComponent : CounterComponent
{
    [SerializeField]
    private IngredientColor color = IngredientColor.Red;

    [SerializeField]
    private Material RedMaterial;
    [SerializeField]
    private Material GreenMaterial;
    [SerializeField]
    private Material BlueMaterial;

    [Header("Ingredient prefabs")]
    [SerializeField]
    private GameObject RedIngredient;
    [SerializeField]
    private GameObject GreenIngredient;
    [SerializeField]
    private GameObject BlueIngredient;

    [SerializeField]
    private List<MeshRenderer> renderersToChangeColor;

    public GameObject IngredientPrefab
    {
        get
        {
            switch (color)
            {
                case IngredientColor.Red:
                    return RedIngredient;
                case IngredientColor.Green:
                    return GreenIngredient;
                case IngredientColor.Blue:
                    return BlueIngredient;
                default:
                    return null;
            }
        }
    }
    public Material IngredientMaterial
    {
        get
        {
            switch (color)
            {
                case IngredientColor.Red:
                    return RedMaterial;
                case IngredientColor.Green:
                    return GreenMaterial;
                case IngredientColor.Blue:
                    return BlueMaterial;
                default:
                    return null;
            }
        }
    }

    private void ApplyMaterial()
    {
        foreach (MeshRenderer renderer in renderersToChangeColor)
        {
            Material mat = IngredientMaterial;
            renderer.sharedMaterial = mat;
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ApplyMaterial();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Interact(Transform player)
    {
        PlayerMovement playerController = player.GetComponent<PlayerMovement>();
        StateMachine stateMachine = playerController.GetStateMachine();
        if (stateMachine.currentState != CarryingState.Instance)
        {
            playerController.pickedUpObject = Instantiate(IngredientPrefab, Vector3.down * 100, Quaternion.identity);
            GameManager.Instance.hudManager.SetIngredient(IngredientPrefab.GetComponent<IngredientComponent>().ingredientColor);
            stateMachine.ChangeState(CarryingState.Instance);
        }
    }

    private void OnValidate()
    {
        ApplyMaterial();
    }
}
