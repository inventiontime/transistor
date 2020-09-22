using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectScript : MonoBehaviour
{
    [Serializable]
    public class ListPositionObjects
    {
        public TextMeshProUGUI text;
        public GameObject star1;
        public GameObject star2;
        public GameObject star3;
    }

    public GameObject[] listPositions;
    public int pageNo;
    public Button leftButton;
    public Button rightButton;

    [Space(1.5f)]
    [Header("Colors")]
    public Color star;
    public Color disabledStar;

    [Space(1.5f)]
    [Header("Prefabs")]
    public GameObject text;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    LevelData[] levels;
    ListPositionObjects[] listPositionObjects;

    int listLength => listPositions.Length;
    int noOfLevels => levels.Length;

    void Start()
    {
        levels = GameManager.Instance.stageData.levels;

        listPositionObjects = new ListPositionObjects[listLength];

        InstantiateList();
        SetList();
    }

    void Update()
    {
        if (pageNo > 0)
            leftButton.interactable = true;
        else
            leftButton.interactable = false;

        if (pageNo < Mathf.Ceil((float)noOfLevels / listLength) - 1)
            rightButton.interactable = true;
        else
            rightButton.interactable = false;
    }

    void InstantiateList()
    {
        for (int i = 0; i < listLength; i++)
        {
            listPositionObjects[i] = new ListPositionObjects();
            listPositionObjects[i].text = Instantiate(text, listPositions[i].transform).GetComponent<TextMeshProUGUI>();
            listPositionObjects[i].star1 = Instantiate(star1, listPositions[i].transform);
            listPositionObjects[i].star2 = Instantiate(star2, listPositions[i].transform);
            listPositionObjects[i].star3 = Instantiate(star3, listPositions[i].transform);
        }
    }

    void SetList()
    {
        LoadSave.Load();
        int i;
        for (i = 0; i < Mathf.Min(listLength, noOfLevels - (pageNo * listLength)); i++)
        {
            int levelIndex = (pageNo * listLength + i);
            int stageIndex = GameManager.Instance.stages.StageIndex(GameManager.Instance.stageData);
            listPositionObjects[i].text.text = (levelIndex + 1).ToString();
            listPositionObjects[i].star1.GetComponent<Image>().color = LoadSave.stars[stageIndex][levelIndex] >= 1 ? star : disabledStar;
            listPositionObjects[i].star2.GetComponent<Image>().color = LoadSave.stars[stageIndex][levelIndex] >= 2 ? star : disabledStar;
            listPositionObjects[i].star3.GetComponent<Image>().color = LoadSave.stars[stageIndex][levelIndex] >= 3 ? star : disabledStar;
        }
        for (; i < listLength; i++)
        {
            listPositionObjects[i].text.text = "";
            listPositionObjects[i].star1.SetActive(false);
            listPositionObjects[i].star2.SetActive(false);
            listPositionObjects[i].star3.SetActive(false);
        }
    }

    public void NextPage()
    {
        pageNo++;
        SetList();
    }

    public void PrevPage()
    {
        if (pageNo > 0)
        {
            SetList();
            pageNo--;
        }
    }

    public void LevelSelected(int i)
    {
        if (pageNo * listLength + i < noOfLevels)
        {
            GameManager.Instance.levelData = levels[pageNo * listLength + i];
            SceneManager.LoadScene("PreLevelTextScene");
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
