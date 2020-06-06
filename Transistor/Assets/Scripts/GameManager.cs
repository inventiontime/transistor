using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelData levelData;

    // Singleton Code

    private static GameManager instance = null;
    public static GameManager Instance => instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

}
