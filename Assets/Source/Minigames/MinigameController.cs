using Unity.VisualScripting;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    int minPoints = 100;
    int actualPoints;
    int maxWidth = 980;
    float actualWidth = 1.0f;

    [SerializeField] GameObject canvas;

    void Start()
    {
    }

    private void FixedUpdate()
    {
    }

    public bool SpamMinigame()
    {
        canvas.SetActive(true);
        while (actualPoints < minPoints)
        {
            
        }
        canvas.SetActive(false);
        return true;
    }
}
