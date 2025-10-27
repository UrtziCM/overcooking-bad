using System.Collections;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MinigameController : MonoBehaviour
{
    int minPoints = 100;
    int actualPoints = 0;
    int maxWidth = 980;
    float actualWidth = 1.0f;

    [SerializeField]
    public GameObject canvas;

    [SerializeField]
    public Image image;

    [SerializeField]
    public InputAction buttonToSpam;

    void Start()
    {
        buttonToSpam.Enable();

        buttonToSpam.performed += _addPointsOnButtonSpam => AddPoints();
    }

    private void FixedUpdate()
    {
        
    }

    private void Update()
    {
        
    }

    public void SpamMinigame(Transform player, CraftingCounterComponent craftingCounterComponent)
    {
        canvas.SetActive(true);
        StartCoroutine(MinigameFinished(player, craftingCounterComponent));
    }

    IEnumerator MinigameFinished(Transform player, CraftingCounterComponent craftingCounterComponent)
    {
        yield return new WaitUntil( () => actualPoints >= minPoints);
        player.GetComponent<PlayerMovement>().GetStateMachine().currentState = IdleState.Instance;
        craftingCounterComponent.MinigameFinished();
        canvas.SetActive(false);
        actualPoints = 0;
    }

    private void ResizeImage()
    {
        image.rectTransform.localScale = Vector3.right * ((float)actualPoints / minPoints) + Vector3.up + Vector3.forward;
    }

    public void AddPoints()
    {
        if ( canvas.activeInHierarchy)
        {
            Debug.Log(actualPoints);
            actualPoints += 10;
            ResizeImage();

        }
    }

}
