using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MinigameController : MonoBehaviour
{
    int minPoints = 100;
    int actualPoints;
    int maxWidth = 980;
    float actualWidth = 1.0f;

    [SerializeField]
    public GameObject canvas;

    [SerializeField]
    public Image image;

    void Start()
    {
    }

    private void FixedUpdate()
    {
        ResizeImage();
    }

    public bool SpamMinigame()
    {
        canvas.SetActive(true);
        while (actualPoints < minPoints)
        {
            actualPoints--;
            if (actualPoints < 1)
            {
                actualPoints = 1;
            }
        }
        canvas.SetActive(false);
        return true;
    }

    private void ResizeImage()
    {
        RectTransform rt = image.rectTransform;
        rt.sizeDelta = new Vector2(actualPoints, rt.sizeDelta.y);
    }
}
