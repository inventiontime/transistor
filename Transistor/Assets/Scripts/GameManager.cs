using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelData levelData;
    public StageData stageData;
    public Stages stages;
    public bool levelCompleted = false;
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSave.SetSize();
    }

    public void LevelCompleted()
    {
        levelCompleted = true;
    }
}
