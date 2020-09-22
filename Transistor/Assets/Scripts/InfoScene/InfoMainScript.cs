 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoMainScript : MonoBehaviour
{
    public Transform[] gateIcons;
    public Transform gateIconHighlight;

    public GameObject NPNTransistor;
    public GameObject PNPTransistor;
    public GameObject Gate;
    public GameObject NOTGate;

    public GateController gateController;

    public int pageNo = 1;

    void Start()
    {
        SetGateOnScreen();
    }

    void SetGateOnScreen()
    {
        gateIconHighlight.position = gateIcons[pageNo - 1].position;

        switch(pageNo)
        {
            case 1:
                NPNTransistor.SetActive(true);
                PNPTransistor.SetActive(false);
                Gate.SetActive(false);
                NOTGate.SetActive(false);
                break;

            case 2:
                NPNTransistor.SetActive(false);
                PNPTransistor.SetActive(true);
                Gate.SetActive(false);
                NOTGate.SetActive(false);
                break;

            case 3:
                NPNTransistor.SetActive(false);
                PNPTransistor.SetActive(false);
                Gate.SetActive(false);
                NOTGate.SetActive(true);
                break;

            case 4:
                NPNTransistor.SetActive(false);
                PNPTransistor.SetActive(false);
                Gate.SetActive(true);
                NOTGate.SetActive(false);

                gateController.ChangeType(GateController.Type.AND);
                break;

            case 5:
                NPNTransistor.SetActive(false);
                PNPTransistor.SetActive(false);
                Gate.SetActive(true);
                NOTGate.SetActive(false);

                gateController.ChangeType(GateController.Type.OR);
                break;

            case 6:
                NPNTransistor.SetActive(false);
                PNPTransistor.SetActive(false);
                Gate.SetActive(true);
                NOTGate.SetActive(false);

                gateController.ChangeType(GateController.Type.NAND);
                break;

            case 7:
                NPNTransistor.SetActive(false);
                PNPTransistor.SetActive(false);
                Gate.SetActive(true);
                NOTGate.SetActive(false);

                gateController.ChangeType(GateController.Type.NOR);
                break;

            case 8:
                NPNTransistor.SetActive(false);
                PNPTransistor.SetActive(false);
                Gate.SetActive(true);
                NOTGate.SetActive(false);

                gateController.ChangeType(GateController.Type.XOR);
                break;

            case 9:
                NPNTransistor.SetActive(false);
                PNPTransistor.SetActive(false);
                Gate.SetActive(true);
                NOTGate.SetActive(false);

                gateController.ChangeType(GateController.Type.XNOR);
                break;
        }
    }

    public void NextPage()
    {
        pageNo++;
        if (pageNo > 9)
            pageNo = 9;
        else
            SetGateOnScreen();
    }

    public void PrevPage()
    {
        pageNo--;
        if (pageNo < 1)
            pageNo = 1;
        else
            SetGateOnScreen();
    }

    public void Back()
    {
        SceneManager.UnloadSceneAsync("InfoScene");
    }
}
