using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class NPC : Interactable
{

    public override void Interact()
    {
        GetComponent<DialogTrigger>().StartDialog();
    }
}
