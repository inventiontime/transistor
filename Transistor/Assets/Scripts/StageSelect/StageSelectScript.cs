using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectScript : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI positionNumber;
    public Button leftButton;
    public Button rightButton;

    public int pageNo;

    private void Start()
    {
        SetList();
    }

    void Update()
    {
        if (pageNo > 0)
            leftButton.interactable = true;
        else
            leftButton.interactable = false;

        if (pageNo < GameManager.Instance.stages.stages.Length - 1)
            rightButton.interactable = true;
        else
            rightButton.interactable = false;
    }

    void SetList()
    {
        title.text = GameManager.Instance.stages.stages[pageNo].stageName.Replace("\\n", "\n");
        positionNumber.text = (pageNo + 1).ToString() + "/" + GameManager.Instance.stages.stages.Length;
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
            pageNo--;
            SetList();
        }
    }

    public void StageSelected()
    {
        GameManager.Instance.stageData = GameManager.Instance.stages.stages[pageNo];
        SceneManager.LoadScene("LevelSelect");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
