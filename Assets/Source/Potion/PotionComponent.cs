using UnityEngine;

public enum PotionColour : byte // RGB Mix
{
    Purple = IngredientColor.Red + IngredientColor.Blue, // R B
    Brown = IngredientColor.Red + IngredientColor.Green, // RG
    Teal = IngredientColor.Green + IngredientColor.Blue, //  GB
    Black = 255
}

public class PotionComponent : MonoBehaviour
{
    public PotionColour PotionColour = PotionColour.Purple;
    private MeshRenderer potionMeshRenderer => transform.GetChild(0).GetComponent<MeshRenderer>();
    [Header("Materials")]
    [SerializeField]
    private Material PurpleMaterial;
    [SerializeField]
    private Material BrownMaterial;
    [SerializeField]
    private Material TealMaterial;
    [SerializeField]
    private Material BlackMaterial;

    private void OnValidate()
    {
        UpdatePotionColour();
    }
    void Start()
    {
        UpdatePotionColour();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdatePotionColour()
    {

        switch (PotionColour)
        {
            case PotionColour.Purple:
                potionMeshRenderer.material = PurpleMaterial;
                break;
            case PotionColour.Brown:
                potionMeshRenderer.material = BrownMaterial;
                break;
            case PotionColour.Teal:
                potionMeshRenderer.material = TealMaterial;
                break;
            default:
                potionMeshRenderer.material = BlackMaterial;
                PotionColour = PotionColour.Black;
                break;

        }
    }
}
