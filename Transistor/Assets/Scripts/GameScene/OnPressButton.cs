using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnPressButton : MonoBehaviour, IPointerDownHandler
{
    [Serializable]
    public class ButtonClickedEvent : UnityEvent { }

    [SerializeField]
    private ButtonClickedEvent OnClick = new ButtonClickedEvent();

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        OnClick.Invoke();
    }
}
