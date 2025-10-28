using UnityEngine;

public class Order
{
    private const float MAX_SCORE_ON_CORRECT_ORDER = 2000;
    public PotionColour targetPotionColour;
    public Order(PotionColour targetPotion)
    {
        this.targetPotionColour = targetPotion;
    }

    public override bool Equals(object obj)
    {
        return targetPotionColour == ((obj as Order).targetPotionColour);
    }

    public bool IsPotionCorrect(PotionColour givenPotion)
    {
        return targetPotionColour == givenPotion;
    }

    public int OrderScore(PotionColour givenPotion, float humourScore = 1f)
    {
        if (IsPotionCorrect(targetPotionColour))
        {
            return (int)(MAX_SCORE_ON_CORRECT_ORDER * humourScore);
        } else 
            return 0;
    }
}
