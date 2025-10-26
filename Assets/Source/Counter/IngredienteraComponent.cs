using UnityEngine;

enum IngredientColor : byte
{
    Red,
    Green,
    Blue
}

public class IngredienteraComponent : CounterComponent
{
    [SerializeField]
    private IngredientColor color = IngredientColor.Red;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
