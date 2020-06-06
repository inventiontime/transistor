using UnityEngine;
using UnityEngine.UI;

public class ModeHandler : MonoBehaviour
{
    public enum Mode { Wire, Move, Delete, Interact, Edit }
    public enum EditPanel { None, Letter, Number }
    public Button WireButton;
    public Button MoveButton;
    public Button DeleteButton;
    public Button InteractButton;
    public Button EditButton;

    public GameObject ButtonA;
    public GameObject ButtonB;
    public GameObject ButtonC;
    public GameObject ButtonD;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public static Mode mode;
    public static DeviceScript selectedDevice;
    public static EditPanel editPanelState = EditPanel.None;
    public EditPanel currentEditPanelState = EditPanel.None;

    void Start()
    {
        ButtonPressed(0);
    }

    private void Update()
    {
        if (editPanelState != currentEditPanelState)
        {
            switch (editPanelState)
            {
                case EditPanel.None:
                    HideEditPanel();
                    break;

                case EditPanel.Letter:
                    ShowEditLetterPanel();
                    break;

                case EditPanel.Number:
                    ShowEditNumberPanel();
                    break;
            }
            currentEditPanelState = editPanelState;
        }
    }

    public void ButtonPressed(int button)
    {
        mode = (Mode)button;
        MakeInactive(button);
    }

    public void EditButtonPressed(int button)
    {
        editPanelState = EditPanel.None;
        selectedDevice.SetText(button);
    }

    void MakeInactive(int button)
    {
        WireButton.interactable = true;
        MoveButton.interactable = true;
        DeleteButton.interactable = true;
        InteractButton.interactable = true;
        EditButton.interactable = true;

        switch ((Mode)button)
        {
            case Mode.Wire:
                WireButton.interactable = false;
                break;

            case Mode.Move:
                MoveButton.interactable = false;
                break;

            case Mode.Delete:
                DeleteButton.interactable = false;
                break;

            case Mode.Interact:
                InteractButton.interactable = false;
                break;

            case Mode.Edit:
                EditButton.interactable = false;
                break;
        }
    }

    void HideEditPanel()
    {
        ButtonA.SetActive(false);
        ButtonB.SetActive(false);
        ButtonC.SetActive(false);
        ButtonD.SetActive(false);
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
    }

    void ShowEditLetterPanel()
    {
        ButtonA.SetActive(true);
        ButtonB.SetActive(true);
        ButtonC.SetActive(true);
        ButtonD.SetActive(true);
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
    }

    void ShowEditNumberPanel()
    {
        ButtonA.SetActive(false);
        ButtonB.SetActive(false);
        ButtonC.SetActive(false);
        ButtonD.SetActive(false);
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
    }
}
