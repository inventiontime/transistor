using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircuitVerificationScript : MonoBehaviour
{
    public GameObject ConfirmationFill;

    public float fillTime;
    public float waitTime;

    float rowThickness;

    int fillingIndex;
    float filledTime;
    bool verifying;
    GameObject prevFill;
    LabelHandler labelHandler;

    List<GameObject> allPrevFill = new List<GameObject>();
    RectTransform rectTransform => transform as RectTransform;

    void Start()
    {
        rowThickness = Mathf.Min(rectTransform.sizeDelta.x / GameManager.Instance.levelData.columns, rectTransform.sizeDelta.y / GameManager.Instance.levelData.rows);
        labelHandler = FindObjectOfType<LabelHandler>();

        ResetVerification();
    }

    void Update()
    {
        if (verifying)
        {
            ///////// Visuals
            if (fillingIndex < GameManager.Instance.levelData.rows)
            {
                filledTime += Time.deltaTime;

                if (filledTime >= fillTime)
                {
                    if (fillingIndex != 0)
                        (prevFill.transform as RectTransform).sizeDelta
                        = new Vector2(rectTransform.sizeDelta.x, rowThickness);


                    fillingIndex++;
                    filledTime = 0;

                    prevFill = Instantiate(ConfirmationFill, transform);

                    allPrevFill.Add(prevFill);

                    (prevFill.transform as RectTransform).anchoredPosition
                    = new Vector2(0, -rowThickness * (fillingIndex + 0.5f));

                    (prevFill.transform as RectTransform).sizeDelta
                    = new Vector2(0, rowThickness);

                    filledTime = 0;
                }
                else
                {
                    (prevFill.transform as RectTransform).sizeDelta
                    = new Vector2(rectTransform.sizeDelta.x * filledTime / fillTime, rowThickness);
                }
            }
            else
            {
                GameManager.Instance.LevelCompleted();
            }

            ///////// Verification
            if (fillingIndex < GameManager.Instance.levelData.rows)
            {
                if (filledTime == 0)
                {
                    for (int i = 0; i < GameManager.Instance.levelData.noOfInputs; i++)
                    {
                        foreach (var x in labelHandler.GetButtons(GameManager.Instance.levelData.header[i]))
                            x.state = GameManager.Instance.levelData.TruthTable[fillingIndex - 1].list[i];
                    }
                }
                else if (filledTime > waitTime)
                {
                    for (int i = GameManager.Instance.levelData.noOfInputs; i < GameManager.Instance.levelData.columns; i++)
                    {
                        if (labelHandler.GetLights(GameManager.Instance.levelData.header[i]).Count == 0)
                        {
                            prevFill.GetComponent<Image>().color = new Color(1, 0, 0, 0.25f);
                            (prevFill.transform as RectTransform).sizeDelta = new Vector2(rectTransform.sizeDelta.x, rowThickness);
                            verifying = false;
                        }
                        else
                        {
                            foreach (var x in labelHandler.GetLights(GameManager.Instance.levelData.header[i]))
                            {
                                if (x.state != GameManager.Instance.levelData.TruthTable[fillingIndex - 1].list[i])
                                {
                                    prevFill.GetComponent<Image>().color = new Color(1, 0, 0, 0.25f);
                                    (prevFill.transform as RectTransform).sizeDelta = new Vector2(rectTransform.sizeDelta.x, rowThickness);
                                    verifying = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void ResetVerification()
    {
        verifying = false;
        prevFill = null;
        fillingIndex = 0;
        filledTime = fillTime;

        foreach (GameObject x in allPrevFill)
            Destroy(x);

        allPrevFill = new List<GameObject>();
    }

    public void StartVerification()
    {
        ResetVerification();
        verifying = true;
    }
}
