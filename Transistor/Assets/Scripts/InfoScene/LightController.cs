using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject lightShader;
    public GameObject lightObject;

    public bool state = false;

    void Update()
    {
        SetActive(state);
    }

    void SetActive(bool state)
    {
        lightObject.SetActive(state);
        lightShader.SetActive(!state);
    }
}
