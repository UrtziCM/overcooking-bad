using UnityEngine;
using UnityEngine.UIElements;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryGameObject;

    [Header("Resources")]
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private Sprite RedIngredientIcon;
    [SerializeField]
    private Sprite BlueIngredientIcon;
    [SerializeField]
    private Sprite GreenIngredientIcon;


    public void SetIngredient(IngredientColor ingredientColor)
    {
        switch (ingredientColor)
        {
            case IngredientColor.Red:
                inventoryGameObject.GetComponent<Image>().sprite = RedIngredientIcon;
                break;
            case IngredientColor.Green:
                inventoryGameObject.GetComponent<Image>().sprite = GreenIngredientIcon;
                break;
            case IngredientColor.Blue:
                inventoryGameObject.GetComponent<Image>().sprite= BlueIngredientIcon;
                break;
            default:
                inventoryGameObject.GetComponent<Image>().sprite = null;
                break;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
