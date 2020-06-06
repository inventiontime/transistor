using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public enum Type { AND, NAND, OR, NOR, XOR, XNOR, NOT }

    public Type type;

    public TerminalScript leftTopTS;
    public TerminalScript leftBottomTS;
    public TerminalScript rightTS;

    public GameObject namePlate;

    void Start()
    {
        List<TerminalScript> terminalList = new List<TerminalScript>();
        terminalList.Add(leftTopTS);
        terminalList.Add(leftBottomTS);
        terminalList.Add(rightTS);

        GetComponent<CommonScript>().terminalList = terminalList;
    }

    void Update()
    {
        switch (type)
        {
            case Type.AND:
                rightTS.state = leftTopTS.state && leftBottomTS.state;
                break;

            case Type.NAND:
                rightTS.state = !(leftTopTS.state && leftBottomTS.state);
                break;

            case Type.OR:
                rightTS.state = leftTopTS.state || leftBottomTS.state;
                break;

            case Type.NOR:
                rightTS.state = !(leftTopTS.state || leftBottomTS.state);
                break;

            case Type.XOR:
                rightTS.state = leftTopTS.state ^ leftBottomTS.state;
                break;

            case Type.XNOR:
                rightTS.state = !(leftTopTS.state ^ leftBottomTS.state);
                break;

            case Type.NOT:
                rightTS.state = !(leftTopTS.state);
                break;
        }
    }
}
