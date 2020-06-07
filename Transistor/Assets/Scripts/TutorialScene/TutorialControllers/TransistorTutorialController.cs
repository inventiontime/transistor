using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransistorTutorialController : MonoBehaviour
{
    public TextMeshProUGUI textObject;

    [Serializable]
    public class TransistorDataset
    {
        public GameObject transistor;
        public TutorialTransistorController transistorController;
        public TutorialButton topButton;
        public TutorialButton leftButton;
        public TutorialLight light;
        [HideInInspector]
        public string[] text;
    }

    public TransistorDataset NPN;
    public TransistorDataset PNP;
    public float timeBetweenChar;

    int tutorialStage = -1;
    bool showingText;
    bool skipped;

    void Start()
    {
        string[] text1 = {
            "This is an NPN transistor! \n\n" +
            "A transistor is a switch that can be controlled by electricity.",

            "Now you can see through the chip.\n\n" +
            "See the switch in the center?\n\n" +
            "It's an open switch.",

            "So, the bottom terminal remains off even if the top terminal is powered on.",

            "Now, if the left terminal is switched on...\n\n" +
            "...the switch closes and electricity can flow from the top to the bottom.",

            "So, the bottom terminal turns on if the top terminal is powered on.",

            "Now you can interact with the transistor yourself; " +
            "tap the buttons to turn them on or off.",

            "Make sure you understand it!"
        };

        NPN.text = text1;

        string[] text2 = {
            "This is a PNP transistor! \n\n" +
            "Its similar to the NPN transistor, except that the switch is closed when the left terminal is off",

            "Now, if the left terminal is switched on...\n\n" +
            "...the switch is open and electricity cannot flow from the top terminal to the bottom.",

            "Now try interacting with the transistor yourself.",

            "Make sure you understand it!"
        };

        PNP.text = text2;

        NextStage();
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
                ShowText("PART C");
                break;

            case 1:
                ShowText(NPN.text[0]);
                break;

            case 2:
                NPN.transistorController.FadeCasing(true);
                ShowText(NPN.text[1]);
                break;

            case 3:
                NPN.topButton.SetState(true);
                ShowText(NPN.text[2]);
                break;

            case 4:
                NPN.topButton.SetState(false);
                NPN.leftButton.SetState(true);
                ShowText(NPN.text[3]);
                break;

            case 5:
                NPN.topButton.interactable = false;
                NPN.leftButton.interactable = false;
                NPN.topButton.SetState(true);
                ShowText(NPN.text[4]);
                break;

            case 6:
                NPN.topButton.interactable = true;
                NPN.leftButton.interactable = true;
                ShowText(NPN.text[5]);
                break;

            case 7:
                NPN.transistor.SetActive(true);
                PNP.transistor.SetActive(false);
                ShowText(NPN.text[6]);
                break;

            case 8:
                ShowText("PART D");
                NPN.transistor.SetActive(false);
                PNP.transistor.SetActive(true);
                break;

            case 9:
                PNP.transistorController.FadeCasing(true);
                ShowText(PNP.text[0]);
                break;

            case 10:
                PNP.topButton.interactable = false;
                PNP.leftButton.interactable = false;
                PNP.leftButton.SetState(true);
                ShowText(PNP.text[1]);
                break;

            case 11:
                PNP.topButton.interactable = true;
                PNP.leftButton.interactable = true;
                ShowText(PNP.text[2]);
                break;

            case 12:
                ShowText(PNP.text[3]);
                break;

            case 13:
                NextTutorial();
                break;
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
        if(skipped)
            textObject.text = text;
        showingText = false;
    }

    void NextTutorial()
    {
        PlayerPrefs.SetInt("TransistorTutorialCompleted", 1);
        SceneManager.LoadScene("TutorialMenu");
    }
}
