﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Traitor : EventTrigger
{
    public UGM_Controller controller;

    public string getName()
    {
        return gameObject.name;
    }

    public Vector3 getPosition()
    {
        Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        return pos;
    }

    private void send_message(string e)
    {
        controller.touch_logger.Log_EventTrigger(gameObject.name, e);
    }

    public override void OnBeginDrag(PointerEventData data)
    {
        send_message("OnBeginDrag");
    }

    public override void OnCancel(BaseEventData data)
    {
        send_message("OnCancel");
    }

    public override void OnDeselect(BaseEventData data)
    {
        send_message("OnDeselect");
    }

    public override void OnDrag(PointerEventData data)
    {
        send_message("OnDrag");
    }

    public override void OnDrop(PointerEventData data)
    {
        send_message("OnDrop");
    }

    public override void OnEndDrag(PointerEventData data)
    {
        send_message("OnEndDrag");
    }

    public override void OnInitializePotentialDrag(PointerEventData data)
    {
        send_message("OnInitializePotentialDrag");
    }

    public override void OnMove(AxisEventData data)
    {
        send_message("OnMove");
    }

    public override void OnPointerClick(PointerEventData data)
    {
        send_message("OnPointerClick");
    }

    public override void OnPointerDown(PointerEventData data)
    {
        send_message("OnPointerDown");
    }

    public override void OnPointerEnter(PointerEventData data)
    {
        send_message("OnPointerEnter");
    }

    public override void OnPointerExit(PointerEventData data)
    {
        send_message("OnPointerExit");
    }

    public override void OnPointerUp(PointerEventData data)
    {
        send_message("OnPointerUp");
    }

    public override void OnScroll(PointerEventData data)
    {
        send_message("OnScroll");
    }

    public override void OnSelect(BaseEventData data)
    {
        send_message("OnSelect");
    }

    public override void OnSubmit(BaseEventData data)
    {
        send_message("OnSubmit");
    }

    public override void OnUpdateSelected(BaseEventData data)
    {
        send_message("OnUpdateSelected");
    }
}
