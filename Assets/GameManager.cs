using UnityEngine;

public class GameManager : MonoBehaviour {
    
    private static GameManager instance;
    
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogWarning("Game manager is NULL");
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public GameObject currentInteractror { get; set; }

    public void openMinigame() { }

}
