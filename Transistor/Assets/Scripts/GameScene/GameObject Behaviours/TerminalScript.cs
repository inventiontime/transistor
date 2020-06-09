using System.Collections.Generic;
using UnityEngine;

public class TerminalScript : MonoBehaviour
{
    public enum Type { IN, OUT };
    public Type type;
    public bool state = false;
    public bool wireConnected = false;
    public List<GameObject> wires = new List<GameObject>();

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && ModeHandler.mode == ModeHandler.Mode.Wire)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;

            if (gameObject.GetComponent<BoxCollider2D>().bounds.Contains(position))
            {
                if (WireCreationHandler.selectedTerminal != gameObject)
                {
                    if (WireCreationHandler.selectedTerminal == null)
                        WireCreationHandler.selectedTerminal = gameObject;
                    else if (WireCreationHandler.selectedTerminal.GetComponent<TerminalScript>().type == type)
                        WireCreationHandler.selectedTerminal = gameObject;
                    else
                        WireCreationHandler.selectedTerminal2 = gameObject;
                }
                else
                {
                    WireCreationHandler.selectedTerminal = null;
                }
            }
        }

        if (WireCreationHandler.selectedTerminal != gameObject)
        {
            Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
            tmp.a = 0f;
            gameObject.GetComponent<SpriteRenderer>().color = tmp;
        }
        else
        {
            Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            gameObject.GetComponent<SpriteRenderer>().color = tmp;
        }

        if (!wireConnected && type == Type.IN)
        {
            state = false;
        }
    }
}