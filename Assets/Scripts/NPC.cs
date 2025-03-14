using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class NPC : MonoBehaviour
{

    public void Interact()
    {
        GetComponent<DialogTrigger>().StartDialog();
    }
}
