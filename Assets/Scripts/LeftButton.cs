using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private HeadController head;
    private void Start()
    {
        head = GameObject.Find("Snake").GetComponentInChildren<HeadController>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        head.LeftButtonDown();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        head.ButtonUp();
    }
}
