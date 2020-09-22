using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompletetionMenu : MonoBehaviour
{
    public GameObject menu;
    public TextMeshProUGUI title;
    public Image star1;
    public Image star2;
    public Image star3;

    [Space(1.5f)]
    [Header("Colors")]
    public Color star;
    public Color disabledStar;

    void Update()
    {
        if (GameManager.Instance.levelCompleted)
            ShowCompletionMenu();
    }

    private void ShowCompletionMenu()
    {
        menu.SetActive(true);

        int noOfGates = FindObjectsOfType<GateScript>().Length + FindObjectsOfType<TransistorScript>().Length;
        int stars;

        if (noOfGates <= GameManager.Instance.levelData.minNoOfGates)
            stars = 3;
        else if (noOfGates == GameManager.Instance.levelData.minNoOfGates + 1)
            stars = 2;
        else
            stars = 1;

        switch (stars)
        {
            case 1:
                star1.color = star;
                star2.color = disabledStar;
                star3.color = disabledStar;
                title.text = "SOLVED!";
                break;

            case 2:
                star1.color = star;
                star2.color = star;
                star3.color = disabledStar;
                title.text = "NICE!";
                break;

            case 3:
                star1.color = star;
                star2.color = star;
                star3.color = star;
                title.text = "PERFECT!";
                break;
        }

        int levelIndex = GameManager.Instance.stageData.LevelIndex(GameManager.Instance.levelData);
        int stageIndex = GameManager.Instance.stages.StageIndex(GameManager.Instance.stageData);

        LoadSave.Load();
        LoadSave.stars[stageIndex][levelIndex] = stars;
        LoadSave.Save();
    }

    public void NextLevel()
    {
        int levelIndex = GameManager.Instance.stageData.LevelIndex(GameManager.Instance.levelData);
        if (levelIndex < GameManager.Instance.stageData.levels.Length - 1)
        {
            GameManager.Instance.levelData = GameManager.Instance.stageData.levels[levelIndex + 1];
            SceneManager.LoadScene("PreLevelTextScene");
        }
        else
        {
            StageSelect();
        }
    }

    public void StageSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
