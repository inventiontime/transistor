using UnityEngine;

public class TerminalMask : MonoBehaviour
{
    public DeviceScript.Type type;

    void Update()
    {
        foreach (DeviceScript x in FindObjectsOfType<DeviceScript>())
        {
            if (x.type == type)
            {
                transform.position = x.terminalTS.transform.position;
            }
        }
    }
}
