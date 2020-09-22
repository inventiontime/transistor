using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject lightShader;
    public GameObject lightObject;

    public bool state;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;

            if (gameObject.GetComponent<BoxCollider2D>().bounds.Contains(position))
            {
                state = !state;
                SetActive(state);
            }
        }
    }

    void SetActive(bool state)
    {
        lightObject.SetActive(state);
        lightShader.SetActive(!state);
    }
}
