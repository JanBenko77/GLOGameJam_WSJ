using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private int totalStages;
    [SerializeField]
    private TextMeshProUGUI currentStageText;
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
        if (currentStageText)
            currentStageText.text = "0/" + totalStages;
    }

    public void SetMinigameDone()
    {
        currentStage++;
        if (currentStageText)
            currentStageText.text = currentStage + "/" + totalStages;
        if (currentStage == totalStages)
            allDone = true;

        if (allDone)
            print("yay");
    }
}
