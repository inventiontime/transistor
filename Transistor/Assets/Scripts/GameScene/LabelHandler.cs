using System.Collections.Generic;
using UnityEngine;

public class LabelHandler : MonoBehaviour
{
    public List<DeviceScript> buttonsA;
    public List<DeviceScript> buttonsB;
    public List<DeviceScript> buttonsC;
    public List<DeviceScript> buttonsD;

    public List<DeviceScript> lights1;
    public List<DeviceScript> lights2;
    public List<DeviceScript> lights3;

    private void Start()
    {
        buttonsA = new List<DeviceScript>();
        buttonsB = new List<DeviceScript>();
        buttonsC = new List<DeviceScript>();
        buttonsD = new List<DeviceScript>();

        lights1 = new List<DeviceScript>();
        lights2 = new List<DeviceScript>();
        lights3 = new List<DeviceScript>();
    }

    public List<DeviceScript> GetButtons(char c)
    {
        switch (c)
        {
            case 'A':
                return buttonsA;

            case 'B':
                return buttonsB;

            case 'C':
                return buttonsC;

            case 'D':
                return buttonsD;

            default:
                return null;
        }
    }

    public List<DeviceScript> GetLights(char c)
    {
        switch (c)
        {
            case '1':
                return lights1;

            case '2':
                return lights2;

            case '3':
                return lights3;

            default:
                return null;
        }
    }
}
