using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ChangeScreens))]
public class Door : Interactable
{
    public bool locked;
    public override void Interact()
    {
        base.Interact();
        if (locked) return;
        GetComponent<ChangeScreens>().ScreenChange();
    }

    public void UnlockDoor()
    {
        locked = false;
    }
}
