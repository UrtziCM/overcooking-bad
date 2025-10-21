using UnityEngine;

public class GameManager : MonoBehaviour {
    
    private static GameManager instance;
    
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("Game manager is NULL");
                instance = new GameManager();
                return instance;
            }
            else
            {
                return instance;
            }
        }
    }

    private GameManager() {}

    private void Awake()
    {
        instance = this;
    }

    public GameObject currentInteractror { get; set; }

    public bool OpenMinigame()
    {
        return true;
    }

    public void DeactivatePlayer()
    {
        
    }

    public void ActivatePlayer()
    {

    }
}
