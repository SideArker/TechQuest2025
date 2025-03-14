using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ChangeScreens))]
public class Door : Interactable
{
    public override void Interact()
    {
        base.Interact();

        GetComponent<ChangeScreens>().ScreenChange();
    }
}
