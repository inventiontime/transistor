using System.Collections.Generic;
using UnityEngine;

public class TransistorScript : MonoBehaviour
{
    public enum Type { NPN, PNP }

    public Type type;

    public TerminalScript leftTS;
    public TerminalScript topTS;
    public TerminalScript bottomTS;

    void Start()
    {
        List<TerminalScript> terminalList = new List<TerminalScript>();
        terminalList.Add(leftTS);
        terminalList.Add(topTS);
        terminalList.Add(bottomTS);

        GetComponent<CommonScript>().terminalList = terminalList;
    }

    void Update()
    {
        switch (type)
        {
            case Type.NPN:
                bottomTS.state = (leftTS.state) ? topTS.state : false;
                break;

            case Type.PNP:
                bottomTS.state = (!leftTS.state) ? topTS.state : false;
                break;
        }
    }
}
