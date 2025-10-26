using UnityEngine;

enum IngredientColor : byte
{
    Red,
    Green, 
    Blue
}

public class IngredienteraComponent : MonoBehaviour
{
    [SerializeField]
    private IngredientColor color = IngredientColor.Red;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
