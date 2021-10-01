using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

public class CustomButton : Selectable, IPointerClickHandler
{
    [SerializeField] private ButtonClickedEvent onClick = new ButtonClickedEvent();

    public void SetOnClick(ButtonClickedEvent onClick)
    {
        this.onClick = onClick;
    }

    public ButtonClickedEvent GetOnClick()
    {
        return onClick;
    }

    private void Press()
    {
        if(!IsActive() || !IsInteractable())
        {
            return;
        }

        GetComponent<AudioSource>().Play();
        onClick.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button != PointerEventData.InputButton.Left)
        {
            return;
        }

        Press();
    }
}
