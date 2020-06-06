using System;
using UnityEngine;
using UnityEngine.Events;

public class TutorialButton : MonoBehaviour
{
    [Serializable]
    public class ButtonClickedEvent : UnityEvent { }

    [SerializeField]
    private ButtonClickedEvent OnClickTrue = new ButtonClickedEvent();
    [SerializeField]
    private ButtonClickedEvent OnClickFalse = new ButtonClickedEvent();

    public bool state = false;
    public bool interactable = false;

    public GameObject lightShader;
    public GameObject lightObject;

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && interactable)
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

    public void SetState(bool newState)
    {
        state = newState;
        SetActive(state);
    }
}
