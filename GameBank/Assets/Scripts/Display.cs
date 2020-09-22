using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Display : MonoBehaviour
{
    Controller controller;

    public TextMeshProUGUI text;
    
    void Start()
    {
        controller = FindObjectOfType<Controller>();
    }

    void Update()
    {
        text.text = controller.displayNumber.ToString();
    }
}
