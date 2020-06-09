using UnityEngine;

public class WireScript : MonoBehaviour
{
    public GameObject outTerminal;
    public GameObject inTerminal;
    public GameObject wireSprite;

    Vector2 inCoord;
    Vector2 outCoord;
    Vector2 diffCoord;

    void Update()
    {
        inTerminal.GetComponent<TerminalScript>().state = outTerminal.GetComponent<TerminalScript>().state;
    }

    public void Refresh()
    {
        inCoord = inTerminal.transform.position;
        outCoord = outTerminal.transform.position;

        diffCoord = inCoord - outCoord;

        // set wire
        wireSprite.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(diffCoord.y, diffCoord.x) * Mathf.Rad2Deg);
        wireSprite.transform.position = new Vector2(outCoord.x + (diffCoord.x / 2), outCoord.y + (diffCoord.y / 2));
        wireSprite.transform.localScale = new Vector2(Vector2.Distance(inCoord, outCoord) / 2, 0.5f);
    }

    public void DestroySelf()
    {
        inTerminal.GetComponent<TerminalScript>().wires.Remove(gameObject);
        outTerminal.GetComponent<TerminalScript>().wires.Remove(gameObject);

        inTerminal.GetComponent<TerminalScript>().wireConnected = false;
        if (outTerminal.GetComponent<TerminalScript>().wires.Count == 0)
            outTerminal.GetComponent<TerminalScript>().wireConnected = false;

        Destroy(gameObject);
    }
}
