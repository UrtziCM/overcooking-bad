using UnityEngine;

public class OrderFactory
{
    static readonly PotionColour[] PotionColours = { PotionColour.Purple, PotionColour.Brown, PotionColour.Teal };
    public static Order GenerateOrder(PotionColour potion)
    {
        return new Order(potion);
    }

    public static Order GenerateRandomOrder()
    {
        return new Order(PotionColours[Random.Range(0, 3)]);
    }
}
