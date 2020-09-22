using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public enum Type { AND, OR, NAND, NOR, XOR, XNOR }
    public Type type;

    public SpriteRenderer text;

    public ButtonController topButton;
    public ButtonController bottomButton;
    public LightController rightLight;

    public Sprite[] textSprites;

    void Update()
    {
        switch (type)
        {
            case Type.AND:
                rightLight.state = topButton.state && bottomButton.state;
                break;

            case Type.NAND:
                rightLight.state = !(topButton.state && bottomButton.state);
                break;

            case Type.OR:
                rightLight.state = topButton.state || bottomButton.state;
                break;

            case Type.NOR:
                rightLight.state = !(topButton.state || bottomButton.state);
                break;

            case Type.XOR:
                rightLight.state = topButton.state ^ bottomButton.state;
                break;

            case Type.XNOR:
                rightLight.state = !(topButton.state ^ bottomButton.state);
                break;
        }
    }

    public void ChangeType(Type type)
    {
        text.sprite = textSprites[(int)type];
        this.type = type;
    }
}
