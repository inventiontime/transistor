using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLevelTextScript : MonoBehaviour
{
    public TextMeshProUGUI textObject;

    bool showingText;
    bool skipped;

    public float timeBetweenChar;


    void Start()
    {
        if (GameManager.Instance.levelData.preLevelText == "")
            SceneManager.LoadScene("GameScene");
        else
            ShowText(GameManager.Instance.levelData.preLevelText);
    }

    void ShowText(string text)
    {
        textObject.text = "";
        StartCoroutine(ShowTextCoroutine(text));
    }

    IEnumerator ShowTextCoroutine(string text)
    {
        showingText = true;
        skipped = false;
        int i = 0;
        while (i < text.Length && !skipped)
        {
            textObject.text += text[i];
            i++;
            yield return new WaitForSeconds(timeBetweenChar);
        }
        if (skipped)
            textObject.text = text;
        showingText = false;
    }

    public void Next()
    {
        if (!showingText)
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            skipped = true;
        }
    }
}
