using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeviceTutorialController : MonoBehaviour
{
    public TextMeshProUGUI textObject;

    public TutorialButton buttonS;
    public TutorialLight lightS;

    public float timeBetweenChar;

    int tutorialStage = -1;
    string[] text;
    bool interacted;
    bool showingText;
    bool skipped;

    void Start()
    {
        string[] t = {
            "On the left is a button, and on the right is a light.\n\n" +
            "Note that a button when switched on supplies power.",

            "The button and the light are connected with a wire.\n\n" +
            "Try tapping the button to interact with it.",

            "Go on, try it!"
        };

        text = t;

        NextStage();
    }

    void Update()
    {
        lightS.state = buttonS.state;
        if (buttonS.state)
            interacted = true;
    }

    public void NextStage()
    {
        if (!showingText)
        {
            tutorialStage++;
            CheckStage();
        }
        else
        {
            skipped = true;
        }
    }

    public void PrevStage()
    {
        tutorialStage--;
        if (tutorialStage < 0)
            tutorialStage = 0;
        else
            CheckStage();
    }

    public void CheckStage()
    {
        switch (tutorialStage)
        {
            case 0:
                ShowText("PART A");
                break;

            case 1:
                buttonS.interactable = false;
                ShowText(text[0]);
                break;

            case 2:
                buttonS.interactable = true;
                ShowText(text[1]);
                break;
        }

        if (tutorialStage >= 3)
        {
            if (!interacted)
            {
                ShowText(text[2]);
            }
            else
            {
                NextTutorial();
            }
        }
    }

    void ShowText(string text)
    {
        textObject.text = "";
        StartCoroutine(ShowTextCoroutine(text, tutorialStage));
    }

    IEnumerator ShowTextCoroutine(string text, int tutorialStage)
    {
        showingText = true;
        skipped = false;
        int i = 0;
        while (tutorialStage == this.tutorialStage && i < text.Length && !skipped)
        {
            textObject.text += text[i];
            i++;
            yield return new WaitForSeconds(timeBetweenChar);
        }
        if (skipped)
            textObject.text = text;
        showingText = false;
    }

    void NextTutorial()
    {
        PlayerPrefs.SetInt("DeviceTutorialCompleted", 1);
        SceneManager.LoadScene("TutorialMenu");
    }
}
