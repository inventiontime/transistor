using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public TextMeshProUGUI textObject;
    public TextMeshProUGUI instructionTextObject;
    public List<GameObject> fadeMasks;

    public float timeBetweenChar;

    public LevelData levelData;

    int tutorialStage = -1;
    string[] text;
    string[] instructionText;

    private void Awake()
    {
        GameManager.Instance.levelData = levelData;
    }

    void Start()
    {
        string[] t = {
            "This button opens the menu to add objects.", // (tap the highlighted button)

            "Drag and drop the switch to where you want to place it (do not tap!)", // 

            "Drag and drop the switch to where you want to place it (do not tap!)", // 

            "Lets add another object.",  // (tap the highlighted button)

            "Drag and drop the light to where you want to place it (do not tap!)", // 

            "Drag and drop the light to where you want to place it (do not tap!)", // 

            "This tool makes wires.", // (tap the highlighted button)

            "Tap on the first terminal to select it", // 

            "Then tap on the second to make a wire. (you can delete a wire by selecting the same two terminals again)", // 

            "This tool moves objects.", // (tap anywhere on the screen)

            "This tool deletes objects.", // (tap anywhere on the screen)

            "This tool is used to press switches.", // (tap anywhere on the screen)

            "This is called the truth table.", // (tap anywhere on the screen)

            "Letters denote inputs, numbers denote outputs.", // (tap anywhere on the screen)

            "The first row means that if switch A is on, the light 1 should also be on.", // (tap anywhere on the screen)

            "The second row means that if switch A is off, the light 1 should also be off.", // (tap anywhere on the screen)

            "This circuit currently functions as such, but the tester needs to know what switch A and light 1 are,", // (tap anywhere on the screen)

            "And that's what this tool does! Select the tool", // (tap the highlighted button)

            "Tap on the switch",

            "Tap A",

            "Similarly, tap on the light",

            "Tap 1",

            "Tap run!"
        };

        text = t;

        string[] t2 = {
            "tap the highlighted button",

            "",

            "",

            "tap the highlighted button",

            "",

            "",

            "tap the highlighted button",

            "",

            "",

            "tap anywhere on the screen",

            "tap anywhere on the screen",

            "tap anywhere on the screen",

            "tap anywhere on the screen",

            "tap anywhere on the screen",

            "tap anywhere on the screen",

            "tap anywhere on the screen",

            "tap anywhere on the screen",

            "tap the highlighted button",

            "",

            "",

            "",

            "",

            ""
        };

        instructionText = t2;

        NextStage();
    }

    void Update()
    {
        bool nextStage = false;

        switch (tutorialStage)
        {
            case 1:
            case 4:
                nextStage = FindObjectOfType<ScreenManager>().currentScreen == "ListScreen";
                break;

            case 2:
                if (FindObjectOfType<GateMoveHandler>().gate != null) nextStage = FindObjectOfType<GateMoveHandler>().gate.GetComponent<DeviceScript>().type == DeviceScript.Type.Button;
                break;

            case 3:
                nextStage = FindObjectOfType<GateMoveHandler>().gate == null;
                break;

            case 5:
                if (FindObjectOfType<GateMoveHandler>().gate != null) nextStage = FindObjectOfType<GateMoveHandler>().gate.GetComponent<DeviceScript>().type == DeviceScript.Type.Light;
                break;

            case 6:
                nextStage = FindObjectOfType<GateMoveHandler>().gate == null;
                break;

            case 7:
                nextStage = ModeHandler.mode == ModeHandler.Mode.Wire;
                break;

            case 8:
                nextStage = WireCreationHandler.selectedTerminal != null || FindObjectOfType<WireScript>() != null;
                break;

            case 9:
                nextStage = FindObjectOfType<WireScript>() != null;
                break;

            case 18:
                nextStage = ModeHandler.mode == ModeHandler.Mode.Edit;
                break;

            case 19:
                if (ModeHandler.selectedDevice != null) nextStage = ModeHandler.selectedDevice.GetComponent<DeviceScript>().type == DeviceScript.Type.Button;
                break;

            case 20:
                nextStage = FindObjectOfType<LabelHandler>().buttonsA.Count != 0;
                break;

            case 21:
                if (ModeHandler.selectedDevice != null) nextStage = ModeHandler.selectedDevice.GetComponent<DeviceScript>().type == DeviceScript.Type.Light;
                break;

            case 22:
                nextStage = FindObjectOfType<LabelHandler>().lights1.Count != 0;
                break;

            case 23:
                if (GameManager.Instance.levelCompleted) { GameManager.Instance.levelCompleted = false; NextTutorial(); }
                break;

            default:
                nextStage = Input.GetMouseButtonDown(0);
                break;
        }

        if (nextStage)
            NextStage();
    }

    public void ShowMask(int index)
    {
        foreach (GameObject x in fadeMasks)
            x.SetActive(false);

        fadeMasks[index].SetActive(true);
    }

    public void NextStage()
    {
        tutorialStage++;
        CheckStage();
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
                ShowText("PART B");
                instructionTextObject.text = "tap anywhere to continue";
                break;

            default:
                ShowText(text[tutorialStage - 1]);
                instructionTextObject.text = instructionText[tutorialStage - 1];
                ShowMask(tutorialStage - 1);
                break;
        }
    }

    void ShowText(string text)
    {
        textObject.text = text;
    }

    void NextTutorial()
    {
        PlayerPrefs.SetInt("EditorTutorialCompleted", 1);
        SceneManager.LoadScene("TutorialMenu");
    }
}
