using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CommonScript : MonoBehaviour
{
    bool colGate;
    bool colTransistor;
    bool colDevice;
    bool colBuildArea;
    bool colBuildAreaEdge;

    GateMoveHandler gateMoveHandler;

    [HideInInspector]
    public List<TerminalScript> terminalList = new List<TerminalScript>();

    void Start()
    {
        gateMoveHandler = (GateMoveHandler)FindObjectOfType(typeof(GateMoveHandler));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;

            if (gameObject.GetComponent<BoxCollider2D>().bounds.Contains(position) && ModeHandler.mode == ModeHandler.Mode.Move)
            {
                gateMoveHandler.gate = gameObject;
                gateMoveHandler.noPrevPosition = false;
                gateMoveHandler.prevPosition = gameObject.transform.position;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;

            if (gameObject.GetComponent<BoxCollider2D>().bounds.Contains(position) && ModeHandler.mode == ModeHandler.Mode.Delete)
            {
                DestroyWires();
                Destroy(gameObject);
            }
        }
    }

    public bool IsInOKPosition()
    {
        return !colGate & !colTransistor & !colDevice & !colBuildAreaEdge & colBuildArea;
    }

    public void ShowTint(bool forceTrue)
    {
        if (IsInOKPosition() || forceTrue)
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        else
            gameObject.GetComponent<SpriteRenderer>().color = Color.gray;

        DeviceScript deviceScript = GetComponent<DeviceScript>();
        if (deviceScript != null)
            deviceScript.ShowTint(IsInOKPosition() || forceTrue);
    }

    public void RefreshWires()
    {
        foreach (TerminalScript terminalScript in terminalList.ToList())
        {
            foreach (GameObject wire in terminalScript.wires.ToList())
            {
                wire.GetComponent<WireScript>().Refresh();
            }
        }
    }

    public void DestroyWires()
    {
        foreach (TerminalScript terminalScript in terminalList.ToList())
        {
            foreach (GameObject wire in terminalScript.wires.ToList())
            {
                wire.GetComponent<WireScript>().DestroySelf();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gate")
            colGate = true;
        else if (collision.gameObject.tag == "Transistor")
            colTransistor = true;
        else if (collision.gameObject.tag == "Device")
            colDevice = true;
        else if (collision.gameObject.name == "BuildArea")
            colBuildArea = true;
        else if (collision.gameObject.name == "BuildAreaEdge")
            colBuildAreaEdge = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gate")
            colGate = false;
        else if (collision.gameObject.tag == "Transistor")
            colTransistor = false;
        else if (collision.gameObject.tag == "Device")
            colDevice = false;
        else if (collision.gameObject.name == "BuildArea")
            colBuildArea = false;
        else if (collision.gameObject.name == "BuildAreaEdge")
            colBuildAreaEdge = false;
    }
}
