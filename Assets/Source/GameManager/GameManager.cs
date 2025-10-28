using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    
    private static GameManager instance;
    private ScoreManager scoreManager;
    [SerializeField]
    public List<int> scores = new List<int>();

    private MinigameController minigameController;

    public HUDManager hudManager;
    public int currentScore;

    [SerializeField]
    public int maxFPS = 60;

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

    private GameManager() {
        scoreManager = new ScoreManager(scores);
    }

    private void Awake()
    {
        instance = this;

        minigameController = gameObject.GetComponent<MinigameController>();

        QualitySettings.vSyncCount = 2;
        Application.targetFrameRate = maxFPS;
    }

    private const int MAX_SCORE_PER_POTION = 2000;

    public void OpenMinigame(Transform player, CraftingCounterComponent craftingCounterComponent)
    {
        minigameController.SpamMinigame(player, craftingCounterComponent);
    }

    public void PotionGiven(float humourIndex) { 
        scoreManager.AddScore((int)(MAX_SCORE_PER_POTION * humourIndex));
    }
}

