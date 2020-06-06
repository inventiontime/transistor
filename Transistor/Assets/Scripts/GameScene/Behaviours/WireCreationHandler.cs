using UnityEngine;

public class WireCreationHandler : MonoBehaviour
{
    public GameObject spawnWireUnder;
    public GameObject wirePrefab;
    public GameObject wireHorizontalPrefab;
    public GameObject wireVerticalPrefab;

    public static GameObject selectedTerminal = null;
    public static GameObject selectedTerminal2 = null;

    GameObject inTerminal;
    GameObject outTerminal;
    GameObject wire;
    GameObject wireSprite;

    void Update()
    {
        if (ModeHandler.mode != ModeHandler.Mode.Wire)
        {
            selectedTerminal = null;
            selectedTerminal2 = null;
        }
        else if (selectedTerminal2 != null)
        {
            // two terminals have been selected

            // sets current input terminal and output terminal
            if (selectedTerminal.GetComponent<TerminalScript>().type == TerminalScript.Type.IN)
            {
                inTerminal = selectedTerminal;
                outTerminal = selectedTerminal2;
            }
            else
            {
                inTerminal = selectedTerminal2;
                outTerminal = selectedTerminal;
            }


            if (!inTerminal.GetComponent<TerminalScript>().wireConnected)
            {
                // no wire already connected to input terminal;

                // makes wire
                wire = Instantiate(wirePrefab, Vector3.zero, Quaternion.identity);
                wire.transform.SetParent(spawnWireUnder.transform, false);
                wireSprite = Instantiate(wireHorizontalPrefab, Vector3.zero, Quaternion.identity);
                wireSprite.transform.SetParent(wire.transform, false);

                // sets some data
                wire.GetComponent<WireScript>().inTerminal = inTerminal;
                wire.GetComponent<WireScript>().outTerminal = outTerminal;
                wire.GetComponent<WireScript>().wireSprite = wireSprite;
                inTerminal.GetComponent<TerminalScript>().wireConnected = true;
                outTerminal.GetComponent<TerminalScript>().wireConnected = true;

                inTerminal.GetComponent<TerminalScript>().wires.Add(wire);
                outTerminal.GetComponent<TerminalScript>().wires.Add(wire);

                wire.GetComponent<WireScript>().Refresh();
            }
            else if (inTerminal.GetComponent<TerminalScript>().wires[0].GetComponent<WireScript>().outTerminal == outTerminal)
            {
                // same wire was reselected -> it will be destroyed

                GameObject tempWire = inTerminal.GetComponent<TerminalScript>().wires[0];

                inTerminal.GetComponent<TerminalScript>().wires.Remove(tempWire);
                outTerminal.GetComponent<TerminalScript>().wires.Remove(tempWire);

                inTerminal.GetComponent<TerminalScript>().wireConnected = false;
                if (outTerminal.GetComponent<TerminalScript>().wires.Count == 0)
                    outTerminal.GetComponent<TerminalScript>().wireConnected = false;

                Destroy(tempWire);
            }

            selectedTerminal = null;
            selectedTerminal2 = null;
        }
    }
}










///////////////rectillinear wiring
/*if (outCoord.x < inCoord.x)
{
    wire = Instantiate(wirePrefab, new Vector2(0, 0), Quaternion.identity);
    wire.GetComponent<WireScript>().inTerminal = inTerminal;
    wire.GetComponent<WireScript>().outTerminal = outTerminal;
    wireParts[0] = Instantiate(wireHorizontalPrefab, new Vector2(outCoord.x + (diffCoord.x / 4), outCoord.y), Quaternion.identity);
    wireParts[1] = Instantiate(wireVerticalPrefab, new Vector2(outCoord.x + (diffCoord.x / 2), outCoord.y + diffCoord.y / 2), Quaternion.identity);
    wireParts[2] = Instantiate(wireHorizontalPrefab, new Vector2(outCoord.x + (diffCoord.x * 3 / 4), inCoord.y), Quaternion.identity);
    wireParts[0].transform.SetParent(wire.transform, false);
    wireParts[1].transform.SetParent(wire.transform, false);
    wireParts[2].transform.SetParent(wire.transform, false);
    wireParts[0].transform.localScale = new Vector2(diffCoord.x / 4, 0.5f);
    wireParts[1].transform.localScale = new Vector2(0.5f, diffCoord.y / 2);
    wireParts[2].transform.localScale = new Vector2(diffCoord.x / 4, 0.5f);
}*/
