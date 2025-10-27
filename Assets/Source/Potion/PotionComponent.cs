using UnityEngine;

public enum PotionColour : byte // RGB Mix
{
    Purple,     // R B
    Brown,      // RG
    Teal,       //  GB
}

public class PotionComponent : MonoBehaviour
{
    public PotionColour PotionColour = PotionColour.Purple;
    //[SerializeField] 
    //private GameObject potionModel;
    [Header("Materials")]
    [SerializeField]
    private Material PurpleMaterial;
    [SerializeField]
    private Material BrownMaterial;
    [SerializeField]
    private Material TealMaterial;

    private void OnValidate()
    {
        
        //switch (PotionColour)
        //{
        //    case PotionColour.Purple:
        //        potionModel.GetComponent<MeshRenderer>().material = PurpleMaterial;
        //        break;
        //    case PotionColour.Brown:
        //        potionModel.GetComponent<MeshRenderer>().material = BrownMaterial;
        //        break;
        //    case PotionColour.Teal:
        //        potionModel.GetComponent<MeshRenderer>().material = TealMaterial;
        //        break;

        //}
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
