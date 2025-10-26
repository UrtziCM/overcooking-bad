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

    private GameObject RedIngredient;
    private GameObject BlueIngredient;
    private GameObject GreenIngredient;

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
        Renderer renderer = GetComponent<Renderer>();
        Material mat = IngredientMaterial;
        renderer.sharedMaterial = mat;

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

    private void OnValidate()
    {
        ApplyMaterial();
    }
}
