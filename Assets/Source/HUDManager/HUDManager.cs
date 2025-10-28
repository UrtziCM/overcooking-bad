using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
    private Sprite PurplePotion;
    [SerializeField]
    private Sprite BrownPotion;
    [SerializeField]
    private Sprite TealPotion;
    [SerializeField]
    private Sprite BlackPotion;

    private Image inventoryImage;

    public void SetHUDInventoryIcon(IngredientColor ingredientColor)
    {
        switch (ingredientColor)
        {
            case IngredientColor.Red:
                inventoryImage.sprite = RedIngredientIcon;
                break;
            case IngredientColor.Green:
                inventoryImage.sprite = GreenIngredientIcon;
                break;
            case IngredientColor.Blue:
                inventoryImage.sprite = BlueIngredientIcon;
                break;
            default:
                inventoryImage.sprite = null;
                break;
        }
    }

    public void SetHUDInventoryIcon(PotionColour potionColour)
    {
        switch (potionColour)
        {
            case PotionColour.Purple:
                inventoryImage.sprite = PurplePotion;
                break;
            case PotionColour.Brown:
                inventoryImage.sprite = BrownPotion;
                break;
            case PotionColour.Teal:
                inventoryImage.sprite = TealPotion;
                break;
            case PotionColour.Black:
                inventoryImage.sprite = BlackPotion;
                break;
            default:
                inventoryImage.sprite = null;
                break;
        }
    }

    void Start()
    {
        inventoryImage = inventoryGameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
