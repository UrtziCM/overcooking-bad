using UnityEngine;

public enum PotionColour : byte // RGB Mix
{
    Purple,     // R B
    Brown,      // RG
    Teal,       //  GB
}

public class PotionComponent : MonoBehaviour
{
    public PotionColour PotionColour;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
