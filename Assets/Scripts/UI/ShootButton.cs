using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Events;

public class ShootButton : MonoBehaviour, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent<bool> OnHold;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnHold.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnHold.Invoke(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnHold.Invoke(false);
    }
}
