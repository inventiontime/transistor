using UnityEngine;

public class DeviceMask : MonoBehaviour
{
    public DeviceScript.Type type;

    void Update()
    {
        foreach (DeviceScript x in FindObjectsOfType<DeviceScript>())
        {
            if(x.type == type)
            {
                transform.position = x.transform.position;
            }
        }
    }
}
