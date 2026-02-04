using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private int totalStages;
    private int currentStage;
    private static bool allDone;

    void Awake()
    {
        instance = this;
        Initialize();
    }

    public void Initialize()
    {
        allDone = false;
        currentStage = 0;
    }

    public void SetMinigameDone()
    {
        currentStage++;
        if (currentStage == totalStages)
            allDone = true;

        if (allDone)
            print("yay");
    }
}
