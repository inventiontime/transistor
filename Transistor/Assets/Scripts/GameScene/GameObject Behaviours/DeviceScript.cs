using System.Collections.Generic;
using UnityEngine;

public class DeviceScript : MonoBehaviour
{
    public enum Type { Light, Button }

    public Type type;

    public GameObject lightShader;
    public GameObject lightObject;
    public SpriteRenderer text;
    public TerminalScript terminalTS;

    public Sprite A;
    public Sprite B;
    public Sprite C;
    public Sprite D;

    public Sprite S1;
    public Sprite S2;
    public Sprite S3;

    public bool state = true;
    LabelHandler labelHandler;

    void Start()
    {
        List<TerminalScript> terminalList = new List<TerminalScript>();
        terminalList.Add(terminalTS);

        GetComponent<CommonScript>().terminalList = terminalList;
        labelHandler = FindObjectOfType<LabelHandler>();
    }

    public void ShowTint(bool IsInOKPosition)
    {
        if (IsInOKPosition)
            lightObject.GetComponent<SpriteRenderer>().color = Color.green;
        else
            lightObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    private void Update()
    {
        if (type == Type.Button)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                position.z = 0;

                if (gameObject.GetComponent<BoxCollider2D>().bounds.Contains(position))
                {
                    if (ModeHandler.mode == ModeHandler.Mode.Interact)
                    {
                        state = !state;
                    }
                    else if (ModeHandler.mode == ModeHandler.Mode.Edit)
                    {
                        ModeHandler.editPanelState = ModeHandler.EditPanel.Letter;
                        ModeHandler.selectedDevice = this;
                    }
                }
            }
            terminalTS.state = state;
            SetActive(state);
        }
        else if (type == Type.Light)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                position.z = 0;

                if (gameObject.GetComponent<BoxCollider2D>().bounds.Contains(position))
                {
                    if (ModeHandler.mode == ModeHandler.Mode.Edit)
                    {
                        ModeHandler.editPanelState = ModeHandler.EditPanel.Number;
                        ModeHandler.selectedDevice = this;
                    }
                }
            }

            state = terminalTS.state;
            SetActive(state);
        }
    }

    void SetActive(bool state)
    {
        if (type == Type.Light)
        {
            lightShader.SetActive(!state);
        }
        else if (type == Type.Button)
        {
            lightObject.SetActive(state);
            lightShader.SetActive(!state);
        }
    }

    public void SetText(int x)
    {
        if (type == Type.Button)
        {
            switch (x)
            {
                case 1:
                    text.sprite = A;
                    labelHandler.buttonsA.Add(this);
                    break;

                case 2:
                    text.sprite = B;
                    labelHandler.buttonsB.Add(this);
                    break;

                case 3:
                    text.sprite = C;
                    labelHandler.buttonsC.Add(this);
                    break;

                case 4:
                    text.sprite = D;
                    labelHandler.buttonsD.Add(this);
                    break;
            }
        }
        else if (type == Type.Light)
        {
            switch (x)
            {
                case 1:
                    text.sprite = S1;
                    labelHandler.lights1.Add(this);
                    break;

                case 2:
                    text.sprite = S2;
                    labelHandler.lights2.Add(this);
                    break;

                case 3:
                    text.sprite = S3;
                    labelHandler.lights3.Add(this);
                    break;
            }
        }
    }
}
