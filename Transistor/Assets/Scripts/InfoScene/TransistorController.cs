using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransistorController : MonoBehaviour
{
    public enum Type { NPN, PNP }
    public Type type;

    public ButtonController topButton;
    public ButtonController leftButton;
    public LightController bottomLight;

    void Update()
    {
        if (type == Type.NPN) bottomLight.state = topButton.state && leftButton.state;
        if (type == Type.PNP) bottomLight.state = topButton.state && !leftButton.state;
    }
}
